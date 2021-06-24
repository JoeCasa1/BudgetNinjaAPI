using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NinjaSoft.Tools.Finance.BudgetNinja.Common;
using NinjaSoft.Tools.Finance.BudgetNinja.Common.DTOs;

namespace NinjaSoft.Tools.Finance.BudgetNinja.API.BL
{
    public class BudgetEntryService : IBudgetEntryService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public BudgetEntryService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<BudgetEntryViewModel>>> AddBudgetEntry(BudgetEntryInputModel entry)
        {
            _ = await _dataContext.BudgetEntries.AddAsync(_mapper.Map<BudgetEntry>(entry));
            _ = await _dataContext.SaveChangesAsync();
            return await CreateResponse();
        }

        public async Task<ServiceResponse<List<BudgetEntryViewModel>>> DeleteBudgetEntry(int id)
        {
            var entryToRemove = await _dataContext.BudgetEntries.FirstOrDefaultAsync(e => e.Id == id);
            _ = _dataContext.BudgetEntries.Remove(entryToRemove);
            _ = await _dataContext.SaveChangesAsync();
            return await CreateResponse();
        }

        public async Task<ServiceResponse<List<BudgetEntryViewModel>>> GetAllBudgetEntries() => await CreateResponse();

        public async Task<ServiceResponse<BudgetEntryViewModel>> GetBudgetEntry(int id)
        {
            var entry = await _dataContext.BudgetEntries.FirstOrDefaultAsync(b => b.Id == id);
            if (entry == null)
            {
                return CreateResponse(null, false, "Budget Entry does not exist.");
            }

            return CreateResponse(entry, true, "Success");
        }

        public async Task<ServiceResponse<BudgetEntryViewModel>> UpdateBudgetEntry(BudgetEntryUpdateModel updatedEntry)
        {
            var entry = await _dataContext.BudgetEntries.FirstOrDefaultAsync(b => b.Id == updatedEntry.Id);
            if (entry == null)
            {
                return CreateResponse(null, false, "Budget Entry does not exist.");
            }

            // perform the update.
            /////////////////////
            ///

            _ = await _dataContext.SaveChangesAsync();
            return CreateResponse(entry, true, "Success");
        }

        private async Task<ServiceResponse<List<BudgetEntryViewModel>>> CreateResponse()
        {
            var entries = await _dataContext.BudgetEntries.ToListAsync();

            return new ServiceResponse<List<BudgetEntryViewModel>>
            {
                Data = entries.Select(e => _mapper.Map<BudgetEntryViewModel>(e)).ToList(),
                Success = true,
                Message = "Success"
            };
        }

        private ServiceResponse<BudgetEntryViewModel> CreateResponse(BudgetEntry entry, bool success, string message) => new()
        {
            Data = _mapper.Map<BudgetEntryViewModel>(entry),
            Success = success,
            Message = message
        };
    }
}