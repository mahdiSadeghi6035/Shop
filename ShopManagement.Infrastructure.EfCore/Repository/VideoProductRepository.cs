using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.VideoProductApp;
using ShopManagement.Domain.VideoProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class VideoProductRepository : RepositoryBase<long, VideoProduct>, IVideoProductRepository
    {
        private readonly ShopContext _context;

        public VideoProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public VideoProduct Get(long id)
        {
            return _context.VideoProduct.Include(x => x.Products).ThenInclude(x => x.Categorys).ThenInclude(x => x.Groupings)
                .FirstOrDefault(x => x.Id == id);
        }

        public EditVideoProduct GetEdit(long id)
        {
            return _context.VideoProduct.Select(x => new EditVideoProduct
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Type = x.Type,
            }).FirstOrDefault(x => x.Id == id);
        }

        public GetVideo GetVideo(long id)
        {
            return _context.VideoProduct.Select(x => new GetVideo
            {
                Id = x.Id,
                Type = x.Type,
                Video = x.Video
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelVideoProduct> Search(SearchModelVideoProduct searchModel)
        {
            var query = _context.VideoProduct.Include(x => x.Products).Select(x => new ViewModelVideoProduct
            {
                Id = x.Id,
                Video = x.Video,
                Type = x.Type,
                ProductId = x.ProductId,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,
                ProductName = x.Products.Name
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
