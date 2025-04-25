using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace HRManagement.Models
{
    public class Contract
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; }
        public string ContractType { get; set; } // e.g., Full-time, Part-time, Contract
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; set; }
        public string Effect { get; set; }
        public string Terms { get; set; }
        public string DocumentPath { get; set; } // Path to the contract document
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? TimeUpdated { get; set; }
    }
}
