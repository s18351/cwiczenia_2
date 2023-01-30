using ConsoleAppCSV.Models;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace ConsoleAppCSV
{
    enum Formats
    {
        json,
        sdcsdv,
        verr
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Formats requestedFormat;
            if(Enum.TryParse(args[2].ToLower(), true, out requestedFormat))
            {
                switch (requestedFormat)
                {
                    case Formats.json:
                        //JSONWriter.WriteJSON(new UniversityDataReader(args[0]).ReadFile(), args[1]);
                        JSONWriter.WriteJSON(new CSVReader(args[0]).ReadToObject<University>(University.CreateFromCSV), args[1]);
                        break;
                    default:
                        Console.WriteLine("Niezaimplementowane.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nieobsługiwany format, formaty obsługiwane: {0}", string.Join(", ", Enum.GetNames(typeof (Formats))));

            }



        }
    }
}