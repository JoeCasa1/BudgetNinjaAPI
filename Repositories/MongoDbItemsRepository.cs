using BudgetNinjaAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetNinjaAPI.Repositories
{
  public class MongoDbItemsRepository : IBudgetEntryRepository
  {
    private const string databaseName = "BudgetDB";

    private const string collectionName = "BudgetEntries";

    private readonly IMongoCollection<BudgetEntry> EntryCollection;

    private readonly FilterDefinitionBuilder<BudgetEntry> filterBuilder = Builders<BudgetEntry>.Filter;

    public MongoDbItemsRepository(IMongoClient mongoClient)
    {
      var database = mongoClient.GetDatabase(databaseName);
      EntryCollection = database.GetCollection<BudgetEntry>(collectionName);
    }

    public async Task CreateBudgetEntryAsync(BudgetEntry entry)
    {
      await EntryCollection.InsertOneAsync(entry);
    }

    public async Task DeleteBudgetEntryAsync(Guid id)
    {
      var filter = filterBuilder.Eq(x => x.Id, id);
      _ = await EntryCollection.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<BudgetEntry>> GetBudgetEntriesAsync()
    {
      return await EntryCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<BudgetEntry> GetBudgetEntryAsync(Guid id)
    {
      var filter = filterBuilder.Eq(x => x.Id, id);
      return await EntryCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<BudgetEntry>> GetDebtsAsync()
    {
      var filter = filterBuilder.Eq(x => x.EntryType, BudgetEntryType.Debt);
      return await EntryCollection.Find(filter).ToListAsync();
    }

    public async Task UpdateBudgetEntryAsync(BudgetEntry entry)
    {
      var filter = filterBuilder.Eq(x => x.Id, entry.Id);
      _ = await EntryCollection.ReplaceOneAsync(filter, entry);
    }
  }
}