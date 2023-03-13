using _0_Framework.Application;
using CommentManagement.Application.Contract.CommentDiscountApp;
using CommentManagement.Domain.CommentScoreAgg;
using System.Collections.Generic;

namespace CommentManagement.Application
{
    public class CommentScoreApplication : ICommentScoreApplication
    {
        private readonly ICommentScoreRepository _commentScoreRepository;

        public CommentScoreApplication(ICommentScoreRepository commentScoreRepository)
        {
            _commentScoreRepository = commentScoreRepository;
        }

        public OperationResult Create(CreateCommentScore command)
        {
            var operation = new OperationResult();
            var option = new List<CreateCommentScoreOption>();
            var commentScoreOption = new List<CommentScoreOption>();
            option.AddRange(command.Minus);
            option.AddRange(command.Positive);
            foreach (var item in option)
            {
                var scoreOption = new CommentScoreOption(item.Description, item.Operation);
                commentScoreOption.Add(scoreOption);

            }
            var commentScore = new CommentScore(command.ProductId, command.Title, command.Description, command.AccountId, commentScoreOption);
            _commentScoreRepository.Create(commentScore);
            _commentScoreRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ViewModelCommentScoreOption> Log(long id)
        {
            return _commentScoreRepository.Log(id);
        }

        public void Remove(long id)
        {
            var commentScore = _commentScoreRepository.GetBy(id);
            commentScore.Remove();
            _commentScoreRepository.SaveChanges();
        }

        public void Restore(long id)
        {
            var commentScore = _commentScoreRepository.GetBy(id);
            commentScore.Remove();
            _commentScoreRepository.SaveChanges();
        }

        public List<ViewModelCommentScore> Search(SearchModelCommentSocre searchModel)
        {
            return _commentScoreRepository.Search(searchModel);
        }
    }
}
