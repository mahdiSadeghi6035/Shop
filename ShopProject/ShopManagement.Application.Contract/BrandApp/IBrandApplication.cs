using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.BrandApp
{
    public interface IBrandApplication
    {
        OperationResult Create(CreateBrand command);
        OperationResult Edit(EditBrand command);
        EditBrand GetEdit(long id);
        List<ViewModelBrand> Search(SearchModelBrand searchModel);
        List<ViewModelBrand> GetModelBrands();
    }
}
