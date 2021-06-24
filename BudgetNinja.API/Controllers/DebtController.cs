using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetNinjaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NinjaSoft.Tools.Finance.BudgetNinja.Common;
using NinjaSoft.Tools.Finance.BudgetNinja.Common.DTOs;

namespace BudgetNinjaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebtController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public DebtController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry(BudgetEntryInputModel entry) => Ok(await BudgetEntryBL.AddBudgetEntry(entry));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await BudgetEntryBL.DeleteBudgetEntry(id);
            return CheckResponseStatus(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await BudgetEntryBL.GetBudgetEntry(id);
            return CheckResponseStatus(response);
        }

        public async Task<IActionResult> GetAll() => Ok(await BudgetEntryBL.GetAllBudgetEntries());

        [HttpGet]
        [Route("")]
        public async Task<List<DebtItem>> Index()
        {
            var debts = new List<DebtItem>();
            return debts;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBudgetEntry(BudgetEntryUpdateModel updateModel)
        {
            var response = await BudgetEntryBL.UpdateBudgetEntry(updateModel);
            return CheckResponseStatus(response);
        }

        private IActionResult CheckResponseStatus<T>(ServiceResponse<T> response)
        {
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}