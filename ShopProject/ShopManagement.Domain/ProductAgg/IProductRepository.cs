using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        EditProduct GetEdit(long id);
        List<ViewModelProduct> Search(SearchModelProduct searchModel);
        List<ViewModelProduct> GetModelProducts();
    }
}
