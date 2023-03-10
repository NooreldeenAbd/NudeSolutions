using Dev_Assignment.DAL.Data;
using Dev_Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev_Assignment.Services.Interfaces
{
    public interface IInsuranceService
    {

        /// <summary>
        /// Retrives all the insured items
        /// </summary>
        /// <returns>lsit of all isnured items or null</returns>
        Task<List<InsuredItem>> GetInsuredItemsAsyn();
        /// <summary>
        /// Saves a new insured item
        /// </summary>
        /// <param name="item">new insured item</param>
        /// <returns>Id of new item</returns>
        Task<int?> AddInsuredItemAsyn(InsuredItem item);
        /// <summary>
        /// Delets a single isnured item
        /// </summary>
        /// <param name="id">Id of insured item</param>
        /// <returns>True if sucessull, otherwise false</returns>
        Task<bool> DeleteInsuredItemAsyn(int id);
    }
}
