using System.Collections.Generic;

namespace _01_ShopQuery.Contract.Product
{
    public interface IProductQuery
    {
        IEnumerable<ProductModel> GetProduct();
    }
}
