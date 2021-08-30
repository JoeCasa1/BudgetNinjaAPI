using BudgetNinjaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetNinjaAPI.Repositories
{
  public class InMemItemsRepository : IBudgetEntryRepository
  {
    private readonly List<BudgetEntry> entries = new()
    {
      new BudgetEntry
      {
        Id = Guid.Parse("d9928db5-dd59-4cc9-ab32-27e637d8a9df"),
        Name = "Amazon CArd",
        Balance = 23456.81,
        Category = "Debt",
        EntryType = BudgetEntryType.Debt,
        Frequency = 12,
        MininmumPayment = 57
      }
    };

    public async Task CreateBudgetEntryAsync(BudgetEntry entry)
    {
      entries.Add(entry);
      await Task.CompletedTask;
    }

    public async Task<IEnumerable<BudgetEntry>> GetBudgetEntriesAsync()
    {
      return await Task.FromResult(entries);
    }

    public async Task<BudgetEntry> GetBudgetEntryAsync(Guid id)
    {
      return await Task.FromResult(entries.FirstOrDefault(x => x.Id == id));
    }

    public async Task<IEnumerable<BudgetEntry>> GetDebtsAsync()
    {
      return await Task.FromResult(entries.Where(x => x.EntryType == BudgetEntryType.Debt));
    }

    public async Task UpdateBudgetEntryAsync(BudgetEntry entry)
    {
      var index = entries.FindIndex(itemToUpdate => itemToUpdate.Id == entry.Id);
      entries[index] = entry;
      await Task.CompletedTask;
    }

    public async Task DeleteBudgetEntryAsync(Guid id)
    {
      var index = entries.FindIndex(x => x.Id == id);
      entries.RemoveAt(index);
      await Task.CompletedTask;
    }
  }
}