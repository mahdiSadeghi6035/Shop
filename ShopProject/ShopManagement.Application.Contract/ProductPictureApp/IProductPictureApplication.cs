using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductPictureApp
{
    public interface IProductPictureApplication 
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        EditProductPicture GetEdit(long id);
        List<ViewModelProductPicture> Searches(SearchModelProductPicture searchModel);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
