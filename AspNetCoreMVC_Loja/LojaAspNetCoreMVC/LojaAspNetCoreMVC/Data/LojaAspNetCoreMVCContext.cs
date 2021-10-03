using LojaAspNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAspNetCoreMVC.Data
{
    public class LojaAspNetCoreMVCContext : DbContext
    {
        public LojaAspNetCoreMVCContext(DbContextOptions<LojaAspNetCoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Employee { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
