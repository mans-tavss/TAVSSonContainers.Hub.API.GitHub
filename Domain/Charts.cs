using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Domain
{
    public class Charts
    {
        public List<int> Data { get; set; }
        public string Label { get; set; }

        public Charts()
        {
            Data = new List<int>();
        }
    }
}
