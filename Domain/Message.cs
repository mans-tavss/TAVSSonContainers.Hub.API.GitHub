﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Domain
{
    public class Message
    {
        [BsonId]
        public string MessageId { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}
