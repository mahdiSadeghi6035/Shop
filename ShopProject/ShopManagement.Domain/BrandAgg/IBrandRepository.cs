using _0_Framework.Domain;
using ShopManagement.Application.Contract.BrandApp;
using System.Collections.Generic;

namespace ShopManagement.Domain.BrandAgg
{
    public interface IBrandRepository : IRepository<long, Brand>
    {
        EditBrand GetEdit(long id);
        List<ViewModelBrand> Search(SearchModelBrand searchModel);
        List<ViewModelBrand> GetModelBrands();
    }
}
