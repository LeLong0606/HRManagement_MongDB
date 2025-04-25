using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HRManagement.Models
{
    public class Notification
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; } // Reference to Employees._id
        [BsonRepresentation(BsonType.ObjectId)]
        public string SenderId { get; set; } // Reference to Employees._id (who sent the notification)
        public string Type { get; set; } // e.g., Leave Approval, Performance Review
        public string Title { get; set; }
        public string Content { get; set; } // Detailed message
        public RelatedDocument RelatedDocument { get; set; }
        public string Priority { get; set; }
        public bool IsRead { get; set; } // Indicates if the notification has been read
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Date and time when the notification was created
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? ExpiryDate { get; set; } // Date and time when the notification was read
    }

    public class RelatedDocument
    {
        public string Collection { get; set; } // e.g., "LeaveRecord", "PerformanceReview"
        [BsonRepresentation(BsonType.ObjectId)]
        public string DocumentId { get; set; } // Reference to the specific document in the collection
    }
}
