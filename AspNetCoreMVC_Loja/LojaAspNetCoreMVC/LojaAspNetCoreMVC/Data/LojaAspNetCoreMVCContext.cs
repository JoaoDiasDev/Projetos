using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaAspNetCoreMVC.Models;

namespace LojaAspNetCoreMVC.Data
{
    public class LojaAspNetCoreMVCContext : DbContext
    {
        public LojaAspNetCoreMVCContext (DbContextOptions<LojaAspNetCoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<LojaAspNetCoreMVC.Models.Department> Department { get; set; }
    }
}
