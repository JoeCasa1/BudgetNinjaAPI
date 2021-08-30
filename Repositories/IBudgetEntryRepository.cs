using BudgetNinjaAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetNinjaAPI.Repositories
{
  public interface IBudgetEntryRepository
  {
    Task<IEnumerable<BudgetEntry>> GetBudgetEntriesAsync();

    Task<BudgetEntry> GetBudgetEntryAsync(Guid id);

    Task<IEnumerable<BudgetEntry>> GetDebtsAsync();

    Task CreateBudgetEntryAsync(BudgetEntry entry);

    Task UpdateBudgetEntryAsync(BudgetEntry entry);

    Task DeleteBudgetEntryAsync(Guid id);
  }
}