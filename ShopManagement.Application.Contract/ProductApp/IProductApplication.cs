using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductApp
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        EditProduct GetEdit(long id);
        List<ViewModelProduct> Search(SearchModelProduct searchModel);
        List<ViewModelProduct> GetModelProducts();
    }
}
