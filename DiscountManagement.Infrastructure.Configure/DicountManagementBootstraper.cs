using DiscountManagement.Application;
using DiscountManagement.Application.Contract.DiscountApp;
using DiscountManagement.Application.Contract.OccasionalDiscountsApp;
using DiscountManagement.Domain.DiscountAgg;
using DiscountManagement.Domain.OccasionalDiscountsAgg;
using DiscountManagement.Infrastructure.EfCore;
using DiscountManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Infrastructure.Configure
{
    public class DicountManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IDiscountApplication, DiscountApplication>();

            services.AddTransient<IOccasionalDiscountsRepository, OccasionalDiscountsRepository>();
            services.AddTransient<IOccasionalDiscountsApplication, OccasionalDiscountsApplication>();

            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connection));
        }
    }
}
