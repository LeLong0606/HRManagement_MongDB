using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class AttendanceService
    {
        private readonly IMongoCollection<Attendance> _attendances;
        public AttendanceService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _attendances = database.GetCollection<Attendance>(settings.Value.CollectionName.Attendances);
        }
        public async Task<List<Attendance>> GetAllAsync()
        {
            return await _attendances.Find(_ => true).ToListAsync();
        }
        public async Task<List<Attendance>> GetByEmployeeIdAsync(string employeeId)
        {
            return await _attendances.Find(a => a.EmployeeId == employeeId).ToListAsync();
        }
    }
}
