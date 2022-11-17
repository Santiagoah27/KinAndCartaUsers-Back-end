using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace KinUsers.Models
{
    [BsonIgnoreExtraElements]
    public class EmployeeMongoDBModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("EmployeeId")]
        public long EmployeeId { get; set; }

        [BsonElement("FirsName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("TimeWorkingInCompany")]
        public int TimeWorkingInCompany { get; set; }
    }
}

