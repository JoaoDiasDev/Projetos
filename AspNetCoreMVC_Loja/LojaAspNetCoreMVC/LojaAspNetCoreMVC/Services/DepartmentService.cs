using LojaAspNetCoreMVC.Data;
using LojaAspNetCoreMVC.Models;

namespace LojaAspNetCoreMVC.Services
{
    public class DepartmentService
    {
        private readonly LojaAspNetCoreMVCContext _context;

        public DepartmentService(LojaAspNetCoreMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
