using ArticleManagement.Application;
using ArticleManagement.Application.Contract.ArticleApp;
using ArticleManagement.Application.Contract.ArticleCategoryApp;
using ArticleManagement.Application.Contract.VideoApp;
using ArticleManagement.Application.Contract.VideoCategoryApp;
using ArticleManagement.Domain.ArticleAgg;
using ArticleManagement.Domain.ArticleCategoryAgg;
using ArticleManagement.Domain.VideoAgg;
using ArticleManagement.Domain.VideoCategoryAgg;
using ArticleManagement.Infrastructure.EfCore;
using ArticleManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleManagement.Infrastructure.Configure
{
    public class ArticleManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();

            services.AddTransient<IVideoCategoryRepository, VideoCategoryRepository>();
            services.AddTransient<IVideoCategoryApplication, VideoCategoryApplication>();

            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<IVideoApplication, VideoApplication>();

            services.AddDbContext<ArticleContext>(x => x.UseSqlServer(connection));
        }
    }
}
