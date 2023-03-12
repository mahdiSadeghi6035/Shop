using _0_Framework.Application;
using CommentManagement.Application.Contract.CommentApp;
using CommentManagement.Domain.CommentAgg;
using System.Collections.Generic;

namespace CommentManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Cancled(long id)
        {
            var comment = _commentRepository.GetBy(id);
            comment.Cancled();
            _commentRepository.SaveChanges();
        }

        public void Confirmed(long id)
        {
            var comment = _commentRepository.GetBy(id);
            comment.Confirmed();
            _commentRepository.SaveChanges();
        }

        public OperationResult Create(CreateComment command)
        {
            var operation = new OperationResult();
            var comment = new Comment(command.Name,command.Email, command.Message, command.Type, command.OwnerId, command.ParentId);
            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(long parentId,CreateComment command)
        {
            var operation = new OperationResult();
            var getComment = _commentRepository.GetBy(parentId);
            if (getComment == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            var comment = new Comment(command.Name, command.Email, command.Message, getComment.Type, getComment.OwnerId, parentId, true);
            _commentRepository.Create(comment);
            getComment.Confirmed();
            _commentRepository.SaveChanges();
            return operation.Succedded();
        }

        public ViewModelComment GetReplyComment(long id)
        {
            return _commentRepository.GetReplyComment(id);
        }

        public List<ViewModelComment> Search(SearchModelComment command)
        {
          return _commentRepository.Search(command);
        }
    }
}
