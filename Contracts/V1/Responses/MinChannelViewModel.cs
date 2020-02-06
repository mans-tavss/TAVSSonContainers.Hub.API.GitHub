using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Contracts.V1.Responses
{
    public class MinChannelViewModel
    {
        public string ChannelId { get; set; }
        public string ImgPath { get; set; }
        public string Caption { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }

    }
}
