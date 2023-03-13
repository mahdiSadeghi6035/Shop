namespace CommentManagement.Application.Contract.CommentDiscountApp
{
    public class ViewModelCommentScore
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long AccountId { get; set; }
        public bool IsRemove { get; set; }
        public string CreateionDate { get; set; }
    }

}
