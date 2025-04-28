using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class PRService
    {
        private readonly IMongoCollection<PerformanceReview> _performanceReviews;
        public PRService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _performanceReviews = database.GetCollection<PerformanceReview>(settings.Value.CollectionName.PerformanceReviews);
        }
        public async Task<PerformanceReview> CreateAsync(PerformanceReview performanceReview)
        {
            await _performanceReviews.InsertOneAsync(performanceReview);
            return performanceReview;
        }
    }
}
