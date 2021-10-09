using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<Mycontext>
    {
        public Mycontext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=developer;Pwd=123456";
            var optionsBuilder = new DbContextOptionsBuilder<Mycontext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new Mycontext(optionsBuilder.Options);
        }
    }
}
