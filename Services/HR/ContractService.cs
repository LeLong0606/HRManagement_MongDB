using HRManagement.Data;
using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class ContractService
    {
        private readonly IMongoCollection<Contract> _contracts;
        public ContractService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _contracts = database.GetCollection<Contract>(settings.Value.CollectionName.Contracts);
        }
        public async Task CreateAsync(Contract contract)
        {
            await _contracts.InsertOneAsync(contract);
        }
        public async Task<Contract> GetByIdAsync(string id)
        {
            return await _contracts.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task UpdateAsync(string id, Contract updatedContract)
        {
            updatedContract.Id = id;
            updatedContract.TimeUpdated = DateTime.Now;
            await _contracts.ReplaceOneAsync(c => c.Id == id, updatedContract);
        }
    }
}
