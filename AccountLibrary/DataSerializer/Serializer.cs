using AccountLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactLibrary.DataSerializer
{
    public class Serializer
    {
        public static string Path = ConfigurationManager.AppSettings["path"];

        public static void Serialization(List<User> users)
        {
            var jsonString = JsonSerializer.Serialize(users);
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.WriteLine(jsonString);
            }
        }

        public static List<User> Deserialization()
        {
            
            if (File.Exists(Path))
            {
                string JsonString = File.ReadAllText(Path) ;
                return JsonSerializer.Deserialize<List<User>>(JsonString);
            }
            return new List<User>() { new User(101, "Jack", "Denial", true) };

        }
    }
}
