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
    internal static class JSONWriter
    {
        public static void WriteJSON(University university, string destinationPath)
        {
            File.WriteAllText(destinationPath, JsonSerializer.Serialize(university, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }), System.Text.Encoding.Unicode);
        }
    }
}
