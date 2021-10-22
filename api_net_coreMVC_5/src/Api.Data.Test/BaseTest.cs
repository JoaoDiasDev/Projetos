using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private readonly string _dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var mysqlVersion = MySqlServerVersion.LatestSupportedServerVersion;
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<Mycontext>(o =>
            o.UseMySql($"Persist Security Info=True;Server=localhost;Database={_dataBaseName};User=developer;Password=123456", mysqlVersion),
            ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<Mycontext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<Mycontext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
