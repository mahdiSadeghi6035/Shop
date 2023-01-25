using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductPictureApp;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetEdit(long id)
        {
            return _context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.Id == id);
        }

        public ProductPicture Get(long id)
        {
            return _context.ProductPictures.Include(x => x.Products).ThenInclude(x => x.Categorys).ThenInclude(x => x.Groupings).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelProductPicture> Searches(SearchModelProductPicture searchModel)
        {
            var query = _context.ProductPictures.Include(x => x.Products).Select(x => new ViewModelProductPicture
            {
                Id = x.Id,
                ProductName = x.Products.Name,
                CreateionDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
