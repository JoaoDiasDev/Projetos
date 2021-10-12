using Api.Data.Context;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<Mycontext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE")));
            }
            else
            {
                var dbVersion = ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("DB_CONNECTION"));

                serviceCollection.AddDbContext<Mycontext>(
                options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"), ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("DB_CONNECTION"))));
            }
        }
    }
}
