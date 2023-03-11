using DiscountManagement.Application;
using DiscountManagement.Application.Contract.CodeDiscountApp;
using DiscountManagement.Application.Contract.DiscountApp;
using DiscountManagement.Application.Contract.OccasionalDiscountsApp;
using DiscountManagement.Domain.CodeDiscountAgg;
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

            services.AddTransient<ICodeDiscountRepository, CodeDiscountRepository>();
            services.AddTransient<ICodeDiscountApplication, CodeDiscountApplication>();

            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connection));
        }
    }
}
