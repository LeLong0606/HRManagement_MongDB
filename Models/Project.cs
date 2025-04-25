using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HRManagement.Models
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProjectName { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; } // Reference to Departments._id
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> AssignedEmployees { get; set; } // List of Employee IDs
        public double Budget { get; set; }
        public string Status { get; set; } // e.g., Active, Completed, On Hold
    }
}
