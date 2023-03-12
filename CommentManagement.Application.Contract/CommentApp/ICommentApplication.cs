using _0_Framework.Application;
using System.Collections.Generic;

namespace CommentManagement.Application.Contract.CommentApp
{
    public interface ICommentApplication
    {
        OperationResult Create(CreateComment command);
        void Confirmed(long id);
        void Cancled(long id);
        List<ViewModelComment> Search(SearchModelComment command);
        ViewModelComment GetReplyComment(long id);
        OperationResult Create(long parentId, CreateComment command);

    }
}
