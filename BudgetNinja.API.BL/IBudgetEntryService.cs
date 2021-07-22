using System.Collections.Generic;
using System.Threading.Tasks;
using NinjaSoft.Tools.Finance.BudgetNinja.Common;
using NinjaSoft.Tools.Finance.BudgetNinja.Common.DTOs;

namespace NinjaSoft.Tools.Finance.BudgetNinja.API.BL
{
    public interface IBudgetEntryService
    {
        Task<ServiceResponse<List<BudgetEntryViewModel>>> AddBudgetEntry(BudgetEntryInputModel entry);

        Task<ServiceResponse<List<BudgetEntryViewModel>>> DeleteBudgetEntry(int id);

        Task<ServiceResponse<List<BudgetEntryViewModel>>> GetAllBudgetEntries();

        Task<ServiceResponse<BudgetEntryViewModel>> GetBudgetEntry(int id);

        Task<ServiceResponse<BudgetEntryViewModel>> UpdateBudgetEntry(BudgetEntryUpdateModel updatedEntry);
    }
}