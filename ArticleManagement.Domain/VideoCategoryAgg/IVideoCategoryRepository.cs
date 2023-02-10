using _0_Framework.Domain;
using ArticleManagement.Application.Contract.VideoCategoryApp;
using System.Collections.Generic;

namespace ArticleManagement.Domain.VideoCategoryAgg
{
    public interface IVideoCategoryRepository : IRepository<long, VideoCategory>
    {
        EditVideoCategory GetEdit(long id);
        List<ViewModelVideoCategory> Search(SearchModelVideoCategory searchModel);
        List<ViewModelVideoCategory> GetVideoCategory();
        string GetSlug(long id);
    }
}
