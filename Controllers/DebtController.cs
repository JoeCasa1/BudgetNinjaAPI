using BudgetNinjaAPI.DTOs;
using BudgetNinjaAPI.Models;
using BudgetNinjaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetNinjaAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DebtController : ControllerBase
  {
    private readonly ILogger<DebtController> _logger;

    private readonly IBudgetEntryRepository _repository;

    public DebtController(ILogger<DebtController> logger, IBudgetEntryRepository repository)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    public async Task<IEnumerable<BudgetEntry>> GetBudgetEntriesAsync()
    {
      var debts = await _repository.GetDebtsAsync();
      return debts;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BudgetEntry>> GetBudgetEntryAsync(Guid id)
    {
      var debt = await _repository.GetBudgetEntryAsync(id);

      if (debt == null)
      {
        return NotFound();
      }

      return Ok(debt);
    }

    [HttpPost]
    public async Task<ActionResult<BudgetEntry>> CreateDebtEntryAsync(DebtInputDTO entry)
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

      await _repository.CreateBudgetEntryAsync(newEntry);

      return CreatedAtAction(nameof(GetBudgetEntryAsync), new { id = newEntry.Id }, newEntry);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBudgetEntryAsync(Guid id, DebtUpdateDTO entry)
    {
      var existingItem = await _repository.GetBudgetEntryAsync(id);
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

      await _repository.UpdateBudgetEntryAsync(updatedItem);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBudgetEntryAsync(Guid id)
    {
      var existingItem = await _repository.GetBudgetEntryAsync(id);
      if (existingItem is null)
      {
        return NotFound();
      }

      await _repository.DeleteBudgetEntryAsync(id);
      return NoContent();
    }
  }
}