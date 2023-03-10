using Dev_Assignment.DAL.Data;
using Dev_Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev_Assignment.Services.Interfaces
{
    public interface IInsuranceService
    {

        Task<List<InsuredItem>> GetInsuredItemsAsyn();
        Task<int?> AddInsuredItemAsyn(InsuredItem item);
        Task<bool> DeleteInsuredItemAsyn(int id);
    }
}
