using LojaAspNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAspNetCoreMVC.Data
{
    public class LojaAspNetCoreMVCContext : DbContext
    {
        public DbSet<Department>? Department { get; set; }
        public DbSet<Seller>? Seller { get; set; }
        public DbSet<SalesRecord>? SalesRecord { get; set; }


        public LojaAspNetCoreMVCContext(DbContextOptions<LojaAspNetCoreMVCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
