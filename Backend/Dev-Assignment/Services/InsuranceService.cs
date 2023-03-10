using Dev_Assignment.Services.Interfaces;
using Dev_Assignment.DAL.Data;
using Dev_Assignment.DAL.Models;

namespace Dev_Assignment.Services
{
    /// <summary>
    /// Provides methods fro retriving and maneging insured items
    /// </summary>
    public class InsuranceService : IInsuranceService
    {
        private readonly IDataContext _context;
        public InsuranceService(IDataContext context)
        {
            _context = context;
        }

        ///<inheritdoc/>
        public async Task<List<InsuredItem>> GetInsuredItemsAsyn()
        {
            try
            {
                return _context.InsuredItems.ToList();
            }catch (Exception ex)
            {
                return null;
            }
        }

        ///<inheritdoc/>
        public async Task<int?> AddInsuredItemAsyn(InsuredItem item)
        {
            try
            {
                _context.InsuredItems.Add(item);
                _context.SaveChanges();
                return item.Id;
            }catch (Exception ex)
            {
                return null;
            }
        }

        ///<inheritdoc/>
        public async Task<bool> DeleteInsuredItemAsyn(int id)
        {
            try
            {
                var item = _context.InsuredItems.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    _context.InsuredItems.Remove(item);
                    _context.SaveChanges();
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }


    }
}
