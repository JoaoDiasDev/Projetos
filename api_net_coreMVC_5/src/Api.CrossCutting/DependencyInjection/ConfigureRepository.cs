using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceColletion.AddScoped<IUserRepository, UserImplementation>();

            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=developer;Pwd=123456";
            serviceColletion.AddDbContext<Mycontext>(
            options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}
