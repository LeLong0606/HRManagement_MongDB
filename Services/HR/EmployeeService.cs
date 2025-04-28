using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;
        public EmployeeService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _employees = database.GetCollection<Employee>(settings.Value.CollectionName.Employees);
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employees.Find(_ => true).ToListAsync();
        }
        public async Task<Employee?> GetByIdAsync(string id)
        {
            return await _employees.Find(e => e.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Employee employee)
        {
            await _employees.InsertOneAsync(employee);
            //return employee;
        }
        public async Task UpdateAsync(string id, Employee employee)
        {
            await _employees.ReplaceOneAsync(e => e.Id == id, employee);
        }
        public async Task DeleteAsync(string id)
        {
            await _employees.DeleteOneAsync(e => e.Id == id);
        }
    }
}
