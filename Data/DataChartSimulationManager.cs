using Hub.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Data
{
    public class DataChartSimulationManager
    {
        
        public static List<Charts> Get()
        {
            var r = new Random();
            return new List<Charts>() 
            {
              new Charts(){Data = new List<int>{ r.Next(1,40)} , Label = "Data1" },
              new Charts(){Data = new List<int>{ r.Next(1,40)} , Label = "Data2" },
              new Charts(){Data = new List<int>{ r.Next(1,40)} , Label = "Data3" },
              new Charts(){Data = new List<int>{ r.Next(1,40)} , Label = "Data4" },

            
            };
        }

    }
}
