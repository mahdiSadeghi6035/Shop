using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductPictureApp;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {
        EditProductPicture GetEdit(long id);
        List<ViewModelProductPicture> Searches(SearchModelProductPicture searchModel);
        ProductPicture Get(long id);
    }
}
