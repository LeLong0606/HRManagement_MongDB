using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class ProjectService
    {
        private readonly IMongoCollection<Project> _projects;
        public ProjectService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _projects = database.GetCollection<Project>(settings.Value.CollectionName.Projects);
        }
        public async Task<List<Project>> GetAllAsync()
        {
            return await _projects.Find(project => true).ToListAsync();
        }
        public async Task<Project> GetByIdAsync(string id)
        {
            return await _projects.Find(project => project.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Project project)
        {
            await _projects.InsertOneAsync(project);
        }
    }
}
