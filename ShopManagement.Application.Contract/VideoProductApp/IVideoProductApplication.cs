using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.VideoProductApp
{
    public interface IVideoProductApplication
    {
        OperationResult Create(CreateVideoProduct command);
        OperationResult Edit(EditVideoProduct command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditVideoProduct GetEdit(long id);
        List<ViewModelVideoProduct> Search(SearchModelVideoProduct id);
        GetVideo GetVideo(long id);
    }
}
