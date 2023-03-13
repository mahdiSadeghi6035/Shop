using _0_Framework.Application;
using System.Collections.Generic;

namespace CommentManagement.Application.Contract.CommentDiscountApp
{
    public interface ICommentScoreApplication
    {
        OperationResult Create(CreateCommentScore command);
        void Remove(long id);
        void Restore(long id);
        List<ViewModelCommentScore> Search(SearchModelCommentSocre searchModel);
        List<ViewModelCommentScoreOption> Log(long id);
    }
}
