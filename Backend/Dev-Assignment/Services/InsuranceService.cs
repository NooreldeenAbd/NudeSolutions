using Dev_Assignment.Services.Interfaces;
using Dev_Assignment.DAL.Data;
using Dev_Assignment.DAL.Models;

namespace Dev_Assignment.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IDataContext _context;
        public InsuranceService(IDataContext context)
        {
            _context = context;
        }


        public async Task<List<InsuredItem>> GetInsuredItemsAsyn()
        {
            return _context.InsuredItems.ToList();
        }


        public async Task<int> AddInsuredItemAsyn(InsuredItem item)
        {
            _context.InsuredItems.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }


        public async Task<bool> DeleteInsuredItemAsyn(int id)
        {
            var item = _context.InsuredItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _context.InsuredItems.Remove(item);
                _context.SaveChanges();
            }
            return true;
        }


    }
}
