using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HRManagement.Models
{
    public class Salary
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public string PaymentFrequency { get; set; } // e.g., Monthly, Bi-weekly
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? TimeUpdated { get; set; }
    }
}
