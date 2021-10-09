using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IUserService, UserService>();
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=developer;Pwd=123456";
            serviceColletion.AddDbContext<Mycontext>(
            options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }



    }
}
