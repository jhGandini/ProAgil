using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Services;
using ProAgil.Infra.Data;
using ProAgil.Infra.Data.Contexts;
using ProAgil.Infra.Data.Repositories;

namespace ProAgil.Infra.CrossCutting
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ProAgilDev");
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ProAgilContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ILotRepository, LotRepository>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }
    }
}