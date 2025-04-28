using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class LeaveRecordService
    {
        private readonly IMongoCollection<LeaveRecord> _leaveRecords;
        public LeaveRecordService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _leaveRecords = database.GetCollection<LeaveRecord>(settings.Value.CollectionName.LeaveRecords);
        }
        public async Task<LeaveRecord> GetByIdAsync(string id)
        {
            return await _leaveRecords.Find(l => l.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> ApproveLeaveAsync(string id, string comments = null)
        {
            var update = Builders<LeaveRecord>.Update
                .Set(x => x.Status, "Approved")
                .Set(x => x.Comments, comments ?? "Approved by HR");

            var result = await _leaveRecords.UpdateOneAsync(x => x.Id == id, update);
            return result.ModifiedCount > 0;
        }
        public async Task<bool> RejectLeaveAsync(string id, string comments = null)
        {
            var update = Builders<LeaveRecord>.Update
                .Set(x => x.Status, "Rejected")
                .Set(x => x.Comments, comments ?? "Rejected by HR");

            var result = await _leaveRecords.UpdateOneAsync(x => x.Id == id, update);
            return result.ModifiedCount > 0;
        }
    }
}
