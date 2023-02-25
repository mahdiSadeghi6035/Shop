using System.Collections.Generic;

namespace _01_ShopQuery.Contract.Brand
{
    public interface IBrandQuery
    {
        IEnumerable<BrandModel> GetBrands();
    }
}
