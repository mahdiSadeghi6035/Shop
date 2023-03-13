using _0_Framework.Application;
using _0_Framework.Infrastructure;
using CommentManagement.Application.Contract.CommentDiscountApp;
using CommentManagement.Domain.CommentScoreAgg;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace CommentManagement.Infrstructure.EfCore.Repository
{
    public class CommentScoreRepository : RepositoryBase<long, CommentScore>, ICommentScoreRepository
    {
        private readonly CommentContext _context;
        private readonly ShopContext _shopContext;
        public CommentScoreRepository(CommentContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public List<ViewModelCommentScoreOption> Log(long id)
        {
            var commentScore = _context.CommentScores.FirstOrDefault(x => x.Id == id);
            return commentScore.CommentScoreOptions.Select(x => new ViewModelCommentScoreOption
            {
                Id = x.Id,
                CommentScoreId = x.CommentScoreId,
                Description = x.Description,
                Operation = x.Operation
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ViewModelCommentScore> Search(SearchModelCommentSocre searchModel)
        {
            var query = _context.CommentScores.Select(x => new ViewModelCommentScore
            {
                Id = x.Id,
                AccountId = x.AccountId,
                CreateionDate = x.CreationDate.ToFarsi(),
                Description = x.Description,
                IsRemove = x.IsRemove,
                ProductId = x.ProductId,
                Title = x.Title
            });

            var product = _shopContext.Products.Select(x => new { x.Id, x.Name}).ToList();

            if(searchModel.IsRemove)
                query = query.Where(x => x.IsRemove);
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            var commentScore = query.OrderByDescending(x => x.Id).ToList();

            commentScore.ForEach(c => c.ProductName = product.FirstOrDefault(x => x.Id== c.ProductId)?.Name);

            return commentScore;
        }
    }
}
