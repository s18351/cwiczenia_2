using ConsoleAppCSV.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace ConsoleAppCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> logs = new List<string>();


            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("C:\\Users\\jerzy\\Desktop\\APDB\\cwiczenia_2\\ConsoleApp1\\Data\\dane.csv"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
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

                    University u = new University()
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


                    File.WriteAllText("output.json", JsonSerializer.Serialize(u, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }), System.Text.Encoding.Unicode);
                }
            }

            catch (FileNotFoundException e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("Plik nazwa nie istnieje");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (logs.Any())
                {
                    File.WriteAllLines("C:\\Users\\jerzy\\Desktop\\APDB\\cwiczenia_2\\ConsoleApp1\\Data\\logs.txt", logs);
                }
            }
        }
    }
}