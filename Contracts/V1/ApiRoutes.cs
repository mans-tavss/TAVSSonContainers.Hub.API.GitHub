using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api/";

        public const string Version = "v1/";

        public const string Base = Root + Version ;

        public  static class Chat 
        {
            public const string ChatBase = Base + "chat/";

            public const string GetChannel = ChatBase + "{CID}";
            public const string GetChannels = ChatBase + "{IID}";

        }
        public  static class Notification
        {
            public const string NotiBase = Base + "Noti/";
        }


    }
}
