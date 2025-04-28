using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class SalaryService
    {
        private readonly IMongoCollection<Salary> _salaries;
        public SalaryService(IOptions<HRMSetting> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _salaries = database.GetCollection<Salary>(settings.Value.CollectionName.Salaries);
        }
        public async Task<List<Salary>> GetAllAsync()
        {
            return await _salaries.Find(_ => true).ToListAsync();
        }
        public async Task<Salary?> GetByIdAsync(string id)
        {
            return await _salaries.Find(s => s.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Salary salary)
        {
            await _salaries.InsertOneAsync(salary);
        }
        public async Task UpdateAsync(string id, Salary salary)
        {
            salary.Id = id; // Ensure the ID is set
            salary.TimeUpdated = DateTime.UtcNow;
            await _salaries.ReplaceOneAsync(s => s.Id == id, salary);
        }
    }
}
