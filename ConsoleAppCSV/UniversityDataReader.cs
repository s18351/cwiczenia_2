using ConsoleAppCSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ConsoleAppCSV
{
    internal class UniversityDataReader
    {
        string filePath;
        List<string> logs = new List<string>();

        public UniversityDataReader(string filePath)
        {
            this.filePath = filePath;
        }

        public University ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    List<Student> students = new List<Student>();
                    Dictionary<String, int> activeStudies = new Dictionary<String, int>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] strings = line.Split(',');
                        if (strings.Count() != 9) logs.Add(line + "| musi byc 9 kolumn");
                        else if (strings.Any(x => x.Trim().Length == 0)) logs.Add(line + "| pusta wartość");
                        else
                        {
                            var student = new Student()
                            {
                                fname = strings[0],
                                lname = strings[1],
                                studies = new Studies()
                                {
                                    name = strings[2],
                                    mode = strings[3]
                                },
                                indexNumber = strings[4],
                                birthdate = strings[5],
                                email = strings[6],
                                mothersName = strings[7],
                                fathersName = strings[8]
                            };
                            if (students.Contains(student))
                            {
                                logs.Add(line + "| duplikat");
                            }
                            else
                            {
                                if (!activeStudies.ContainsKey(student.studies.name))
                                {
                                    activeStudies.Add(student.studies.name, 1);
                                }
                                else
                                {
                                    activeStudies[student.studies.name]++;
                                }

                                students.Add(student);
                            }
                        }
                    }

                    return new University()
                    {
                        studenci = students,
                        activeStudies = activeStudies.Select(x => new ActiveStudy()
                        {
                            name = x.Key,
                            numberOfStudents = x.Value
                        }).ToList(),
                        author = "Ja",
                        createdAt = DateTime.UtcNow.ToString()
                    };
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Plik nazwa nie istnieje");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (logs.Any())
                {
                    File.WriteAllLines(".\\log.txt", logs);
                }
            }
            return null;
        }

    }
}
