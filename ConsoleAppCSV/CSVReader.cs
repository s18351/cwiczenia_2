using ConsoleAppCSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSV
{
    internal class CSVReader
    {
        string filePath;
        List<string> logs = new List<string>();

        public CSVReader(string filePath)
        {
            this.filePath = filePath;
        }

        public T ReadToObject<T>(Func<string[], List<string>, T> objectReader)
        {
            T result = default(T);
            try
            {
                result = objectReader(File.ReadAllLines(filePath), logs);
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

            return result;
        }
    }
}
