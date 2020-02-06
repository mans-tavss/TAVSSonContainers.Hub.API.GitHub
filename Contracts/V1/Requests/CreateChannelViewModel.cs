using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Contracts.V1.Requests
{
    public class CreateChannelViewModel
    {
        public string AdminId { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
    }
}
