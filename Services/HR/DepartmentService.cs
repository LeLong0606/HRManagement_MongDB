using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class DepartmentService
    {
        private readonly IMongoCollection<Department> _departments;
        public DepartmentService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _departments = database.GetCollection<Department>(settings.Value.CollectionName.Departments);
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _departments.Find(_ => true).ToListAsync();
        }
        public async Task<Department?> GetByIdAsync(string id)
        {
            return await _departments.Find(d => d.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Department department)
        {
            await _departments.InsertOneAsync(department);
        }
        public async Task UpdateAsync(string id, Department department)
        {
            await _departments.ReplaceOneAsync(d => d.Id == id, department);
        }
        public async Task DeleteAsync(string id)
        {
            await _departments.DeleteOneAsync(d => d.Id == id);
        }
    }
}
