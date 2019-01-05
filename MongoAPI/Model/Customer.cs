using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Model
{
    public class Customer
    {
            public ObjectId Id { get; set; }

            [BsonElement("firstName")]
            public string firstName { get; set; }

            [BsonElement("lastName")]
            public string lastName { get; set; }

            [BsonElement("year")]
            public string year { get; set; }
    }
}
