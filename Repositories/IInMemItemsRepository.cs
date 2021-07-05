using BudgetNinjaAPI.Models;
using System;
using System.Collections.Generic;

namespace BudgetNinjaAPI.Repositories
{
  public interface IInMemItemsRepository
  {
    IEnumerable<BudgetEntry> GetBudgetEntries();
    BudgetEntry GetBudgetEntry(Guid id);
    IEnumerable<BudgetEntry> GetDebts();

    void CreateBudgetEntry(BudgetEntry entry);

    void UpdateBudgetEntry(BudgetEntry entry);

    void DeleteBudgetEntry(Guid id);
  }
}