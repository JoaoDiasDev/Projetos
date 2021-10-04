using LojaAspNetCoreMVC.Data;
using LojaAspNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAspNetCoreMVC.Services
{
    public class DepartmentService
    {
        private readonly LojaAspNetCoreMVCContext _context;

        public DepartmentService(LojaAspNetCoreMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name)
                                            .ToListAsync();
        }
    }
}
