using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<Mycontext>
    {
        public Mycontext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var optionsBuilder = new DbContextOptionsBuilder<Mycontext>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {

                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"));
            }
            else
            {
                optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"), ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }
            return new Mycontext(optionsBuilder.Options);
        }
    }
}
