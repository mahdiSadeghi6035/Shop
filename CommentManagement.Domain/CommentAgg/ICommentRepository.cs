using _0_Framework.Domain;
using CommentManagement.Application.Contract.CommentApp;
using System.Collections.Generic;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<ViewModelComment> Search(SearchModelComment command);
        ViewModelComment GetReplyComment(long id);
    }
}
