using InventoryManagement.Application.Contract.InventoryApp;
using InventoryManagement.Application.Contract.WarrantyApp;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Domain.WarrantyAgg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using InventoryManagmenet.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryManagement.Infrastructure.Configure
{
    public class InventoryManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();

            services.AddTransient<IWarrantyRepository, WarrantyRepository>();
            services.AddTransient<IWarrantyApplication, WarrantyApplication>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connection));
        }
    }
}
