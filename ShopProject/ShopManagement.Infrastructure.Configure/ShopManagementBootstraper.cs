﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.BrandApp;
using ShopManagement.Application.Contract.CategoryApp;
using ShopManagement.Application.Contract.GroupingApp;
using ShopManagement.Application.Contract.ProductApp;
using ShopManagement.Domain.BrandAgg;
using ShopManagement.Domain.CategoryAgg;
using ShopManagement.Domain.GroupingAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;

namespace ShopManagement.Infrastructure.Configure
{
    public class ShopManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddTransient<IGroupingRepository, GroupingRepository>();
            services.AddTransient<IGroupingApplication, GroupingApplication>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryApplication, CategoryApplication>();

            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandApplication, BrandApplication>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connection));
        }
    }
}
