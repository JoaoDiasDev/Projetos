using LojaAspNetCoreMVC.Data;
using LojaAspNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAspNetCoreMVC.Services
{
    public class SalesRecordService
    {
        private readonly LojaAspNetCoreMVCContext _context;

        public SalesRecordService(LojaAspNetCoreMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(xmethod => xmethod.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
