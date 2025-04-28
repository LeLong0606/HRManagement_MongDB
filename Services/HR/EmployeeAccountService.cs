using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class EmployeeAccountService
    {
        private readonly IMongoCollection<EmployeeAccount> _employeeAccounts;
        public EmployeeAccountService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _employeeAccounts = database.GetCollection<EmployeeAccount>(settings.Value.CollectionName.EmployeeAccounts);
        }
        public async Task<List<EmployeeAccount>> GetAllAsync()
        {
            return await _employeeAccounts.Find(_ => true).ToListAsync();
        }
        public async Task<EmployeeAccount?> GetByIdAsync(string id)
        {
            return await _employeeAccounts.Find(e => e.Id == id).FirstOrDefaultAsync();
        }
        public async Task<EmployeeAccount> GetByEmployeeIdAsync(string employeeId)
        {
            return await _employeeAccounts.Find(a => a.EmployeeId == employeeId).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(EmployeeAccount employeeAccount)
        {
            await _employeeAccounts.InsertOneAsync(employeeAccount);
        }
        public async Task UpdateAsync(string id, EmployeeAccount employeeAccount)
        {
            await _employeeAccounts.ReplaceOneAsync(e => e.Id == id, employeeAccount);
        }
        public async Task DeleteAsync(string id)
        {
            await _employeeAccounts.DeleteOneAsync(e => e.Id == id);
        }
        public async Task UpdateStatusAsync(string id, string status)
        {
            var update = Builders<EmployeeAccount>.Update.Set(e => e.Status, status);
            await _employeeAccounts.UpdateOneAsync(e => e.Id == id, update);
        }
        public async Task UpdateLastLoginAsync(string id, DateTime lastLogin)
        {
            var update = Builders<EmployeeAccount>.Update.Set(e => e.TimeCreated, lastLogin);
            await _employeeAccounts.UpdateOneAsync(e => e.Id == id, update);
        }
    }
}
