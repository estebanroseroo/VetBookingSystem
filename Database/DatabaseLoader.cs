using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetBookingSystem.Database
{
    class DatabaseLoader
    {
        public static Schedule LoadData(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Schedule>(json);
        }
    }
}
