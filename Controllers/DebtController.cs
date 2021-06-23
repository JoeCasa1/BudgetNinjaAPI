using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using BudgetNinjaAPI.Models;

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

        [HttpGet]
        [Route("")]
        public async Task<List<DebtItem>> Index()
        {
            var debts = new List<DebtItem>();
            return debts;
        }
    }
}
