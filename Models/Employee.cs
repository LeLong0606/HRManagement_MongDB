using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HRManagement.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DOB { get; set; }
        public string Position { get; set; }
        public bool IsManager { get; set; }
        public ContractInfo ContractInfo { get; set; }
        public List<EmergencyContact> EmergencyContacts { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? TimeUpdated { get; set; }
        public string Status { get; set; }
    }

    public class ContractInfo
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class EmergencyContact
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string Phone { get; set; }
    }
}
