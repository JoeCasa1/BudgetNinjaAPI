using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using BudgetNinjaAPI.Models;
using BudgetNinjaAPI.Repositories;
using BudgetNinjaAPI.DTOs;

namespace BudgetNinjaAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DebtController : ControllerBase
  {
    private readonly ILogger<DebtController> _logger;
    private readonly IInMemItemsRepository _repository;

    public DebtController(ILogger<DebtController> logger, IInMemItemsRepository repository)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    public IEnumerable<BudgetEntry> GetBudgetEntriesAsync()
    {
      var debts = _repository.GetDebts();
      return debts;
    }

    [HttpGet("{id}")]
    public ActionResult<BudgetEntry> GetBudgetEntry(Guid id)
    {
      var debt = _repository.GetBudgetEntry(id);

      if (debt == null)
      {
        return NotFound();
      }

      return Ok(debt);
    }

    [HttpPost]
    public ActionResult<BudgetEntry> CreateDebtEntry(DebtInputDTO entry)
    {
      BudgetEntry newEntry = new()
      {
        Id = Guid.NewGuid(),
        Name = entry.Name,
        InterestRate = entry.InterestRate,
        MininmumPayment = entry.MinimumPayment,
        Balance = entry.Balance,
        EntryType = BudgetEntryType.Debt,
        Category = "Debt"
      };

      _repository.CreateBudgetEntry(newEntry);

      return CreatedAtAction(nameof(GetBudgetEntry), new { id = newEntry.Id }, newEntry);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateBudgetEntry(Guid id, DebtUpdateDTO entry)
    {
      var existingItem = _repository.GetBudgetEntry(id);
      if (existingItem is null)
      {
        return NotFound();
      }

      var updatedItem = existingItem with
      {
        Id = id,
        Name = entry.Name,
        Balance = entry.Balance,
        MininmumPayment = entry.MinimumPayment
      };

      _repository.UpdateBudgetEntry(updatedItem);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteBudgetEntry(Guid id)
    {
      var existingItem = _repository.GetBudgetEntry(id);
      if (existingItem is null)
      {
        return NotFound();
      }

      _repository.DeleteBudgetEntry(id);
      return NoContent();
    }
  }
}
