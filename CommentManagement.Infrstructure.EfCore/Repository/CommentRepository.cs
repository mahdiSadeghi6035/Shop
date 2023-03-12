using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ArticleManagement.Infrastructure.EfCore;
using CommentManagement.Application.Contract.CommentApp;
using CommentManagement.Domain.CommentAgg;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace CommentManagement.Infrstructure.EfCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _context;
        private readonly ArticleContext _articleContext;
        private readonly ShopContext _shopContext;
        public CommentRepository(CommentContext context, ArticleContext articleContext, ShopContext shopContext) : base(context)
        {
            _context = context;
            _articleContext = articleContext;
            _shopContext = shopContext;
        }

        public ViewModelComment GetReplyComment(long id)
        {
            return _context.Comment.Select(x => new ViewModelComment
            {
                Id = x.Id,
                CreateionDate = x.CreationDate.ToFarsi(),
                Name = x.Name,
                Email = x.Email,
                //Type = x.Type,
                ParrentId = x.ParentId,
                Message = x.Message,
                //TypeName = (x.Type == CommentType.Product) ? "محصول" : "مقاله",
            }).FirstOrDefault(x => x.ParrentId == id);
        }

        public List<ViewModelComment> Search(SearchModelComment command)
        {
            var query = _context.Comment.Select(x => new ViewModelComment
            {
                Id = x.Id,
                CreateionDate = x.CreationDate.ToFarsi(),
                Name = x.Name,
                Email = x.Email,
                Type = x.Type,
                ParrentId = x.ParentId,
                Message = x.Message,
                OwnerId = x.OwnerId,
                IsCancled = x.IsCancled,
                IsConfirmed = x.IsConfirmed,
                TypeName = (x.Type == CommentType.Product) ? CommentType.ProductName : CommentType.ArticleName
            });

            var product = _shopContext.Products.Select(x => new { x.Id, x.Name}).ToList();
            var article = _articleContext.Article.Select(x => new { x.Id, x.Title}).ToList();

            if (command.IsCancled)
                query = query.Where(x => x.IsCancled == command.IsCancled);
            if (command.IsConfirmed)
                query = query.Where(x => x.IsConfirmed == command.IsConfirmed);
            if (command.Type > 0)
                query = query.Where(x => x.Type == command.Type);
            if (!string.IsNullOrWhiteSpace(command.Name))
                query = query.Where(x => x.Name.Contains(command.Name));

            var comment = query.Where(x => x.ParrentId == 0).OrderByDescending(x => x.Id).ToList();
            foreach (var item in query)
            {
                if(item.Type == CommentType.Product)
                {
                    comment.ForEach(c => c.OwnerName = product.FirstOrDefault(p => p.Id == c.OwnerId)?.Name);
                }else if (item.Type == CommentType.Article)
                {
                    comment.ForEach(c => c.OwnerName = article.FirstOrDefault(p => p.Id == c.OwnerId)?.Title);
                }
            }
            return comment;
        }
    }
}
