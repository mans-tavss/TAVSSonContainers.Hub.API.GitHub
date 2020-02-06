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

        public static class Chat
        {
            public const string ChatBase = Base + "chat/";

            public const string GetChannel = ChatBase + "{CID}";
            public const string GetChannels = ChatBase + "{UID}";
            public const string SendMessage = ChatBase + "{CID}/{UID}";
            public const string CreateChannel = ChatBase;
            public const string DeleteChannel = ChatBase;
            public const string ModifyChannel = ChatBase;
            public const string CreateUser = Base + "user/";
            public const string GetUsers = Base + "user/";
            public const string GetUser = Base + "user/{UID}";
            public const string InsertImgtoChannel = ChatBase + "{CID}";
            public const string InsertImgtoUser = ChatBase + "{UID}";





            

        }
        public  static class Notification
        {
            public const string NotiBase = Base + "Noti/";
        }

        public static class Chart
        {
            public const string ChartBase = Base + "Chart/";
            public const string GetChart = ChartBase;

        }


    }
}
