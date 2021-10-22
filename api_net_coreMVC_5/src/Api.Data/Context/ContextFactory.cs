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
            var connectionString = "Persist Security Info = True; Server = localhost; Port = 3306; Database = dbapi; Uid = developer; Pwd = 123456; SslMode = none;";

            var optionsBuilder = new DbContextOptionsBuilder<Mycontext>();

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
            //optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"), ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("DB_CONNECTION")));

            return new Mycontext(optionsBuilder.Options);
        }
    }
}
