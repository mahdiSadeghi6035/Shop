using _0_Framework.Domain;
using CommentManagement.Application.Contract.CommentDiscountApp;
using System.Collections.Generic;

namespace CommentManagement.Domain.CommentScoreAgg
{
    public interface ICommentScoreRepository : IRepository<long, CommentScore>
    {
        List<ViewModelCommentScore> Search(SearchModelCommentSocre searchModel);
        List<ViewModelCommentScoreOption> Log(long id);
    }
}
