using _0_Framework.Domain;
using ShopManagement.Application.Contract.VideoProductApp;
using System.Collections.Generic;

namespace ShopManagement.Domain.VideoProductAgg
{
    public interface IVideoProductRepository : IRepository<long, VideoProduct>
    {
        EditVideoProduct GetEdit(long id);
        List<ViewModelVideoProduct> Search(SearchModelVideoProduct searchModel);
        GetVideo GetVideo(long id);
        VideoProduct Get(long id);
    }
}
