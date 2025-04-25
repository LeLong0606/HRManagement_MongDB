using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HRManagement.Models
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeCreated { get; set; } = DateTime.Now;
    }
}
