using BudgetNinjaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetNinjaAPI.Repositories
{
  public class InMemItemsRepository : IInMemItemsRepository
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

    public void CreateBudgetEntry(BudgetEntry entry)
    {
      entries.Add(entry);
    }

    public IEnumerable<BudgetEntry> GetBudgetEntries()
    {
      return entries;
    }

    public BudgetEntry GetBudgetEntry(Guid id)
    {
      return entries.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<BudgetEntry> GetDebts()
    {
      return entries.Where(x => x.EntryType == BudgetEntryType.Debt);
    }

    public void UpdateBudgetEntry(BudgetEntry entry)
    {
      var index = entries.FindIndex(itemToUpdate => itemToUpdate.Id == entry.Id);
      entries[index] = entry;
    }

    public void DeleteBudgetEntry(Guid id)
    {
      var index = entries.FindIndex(x => x.Id == id);
      entries.RemoveAt(index);
    }
  }
}