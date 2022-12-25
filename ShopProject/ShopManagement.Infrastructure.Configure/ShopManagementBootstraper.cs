using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.GroupingApp;
using ShopManagement.Domain.GroupingAgg;
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

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connection));
        }
    }
}
