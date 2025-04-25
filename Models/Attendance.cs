using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HRManagement.Models
{
    public class Attendance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; } // Date of attendance
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CheckIn { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CheckOut { get; set; }
        public double HoursWorked { get; set; } // Total hours worked for the day
        public string Status { get; set; } // e.g., Present, Absent, Late
    }
}
