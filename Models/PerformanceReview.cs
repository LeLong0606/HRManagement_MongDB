using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HRManagement.Models
{
    public class PerformanceReview
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ReviewDate { get; set; } // Date of the review
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReviewrId { get; set; } // HR/Manager
        public int Rate { get; set; } // 1 - 5
        public string Comments { get; set; }
        public List<string> Goals { get; set; } // e.g., ["Improve communication", "Complete project X"]
    }
}
