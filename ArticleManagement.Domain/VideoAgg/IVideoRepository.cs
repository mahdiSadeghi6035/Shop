using _0_Framework.Domain;
using ArticleManagement.Application.Contract.VideoApp;
using System.Collections.Generic;

namespace ArticleManagement.Domain.VideoAgg
{
    public interface IVideoRepository : IRepository<long, Video>
    {
        EditVideo GetEdit(long id);
        List<ViewModelVideo> Search(SearchModelVideo searchModel);
        Video GetVideo(long id);

    }
}
