using _0_Framework.Application;
using System.Collections.Generic;

namespace ArticleManagement.Application.Contract.VideoApp
{
    public interface IVideoApplication
    {
        OperationResult Create(CreateVideo command);
        OperationResult Edit(EditVideo command);
        EditVideo GetEdit(long id);
        List<ViewModelVideo> Search(SearchModelVideo searchModel);
    }
}
