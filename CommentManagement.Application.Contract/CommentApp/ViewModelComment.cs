namespace CommentManagement.Application.Contract.CommentApp
{
    public class ViewModelComment
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCancled { get; set; }
        public long Type { get; set; }
        public string TypeName { get; set; }
        public long ParrentId { get; set; }
        public string CreateionDate { get;  set; }
        public long OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
