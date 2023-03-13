using CommentManagement.Application;
using CommentManagement.Application.Contract.CommentApp;
using CommentManagement.Application.Contract.CommentDiscountApp;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Domain.CommentScoreAgg;
using CommentManagement.Infrstructure.EfCore;
using CommentManagement.Infrstructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Infrastructure.Configure
{
    public class CommentManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connetion)
        {
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();

            services.AddTransient<ICommentScoreRepository, CommentScoreRepository>();
            services.AddTransient<ICommentScoreApplication, CommentScoreApplication>();

            services.AddDbContext<CommentContext>(x => x.UseSqlServer(connetion));
        }
    }
}
