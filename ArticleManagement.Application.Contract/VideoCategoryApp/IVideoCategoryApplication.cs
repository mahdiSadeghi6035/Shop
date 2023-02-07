using _0_Framework.Application;
using System.Collections.Generic;

namespace ArticleManagement.Application.Contract.VideoCategoryApp
{
    public interface IVideoCategoryApplication
    {
        OperationResult Create(CreateVideoCategory command);
        OperationResult Edit(EditVideoCategory commnand);
        EditVideoCategory GetEdit(long id);
        List<ViewModelVideoCategory> Search(SearchModelVideoCategory searchModel);
        List<ViewModelVideoCategory> GetVideoCategory();
    }
}
