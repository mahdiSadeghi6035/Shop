using _0_Framework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : DomainBase<long>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public long Type { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCancled { get; private set; }
        public long OwnerId { get; private set; }
        public long ParentId { get; private set; }
        //public Comment Parent { get; private set; }

        public Comment()
        {
        }

        public Comment(string name, string email, string message, long type, long ownerId, long parrentId)
        {
            Name = name;
            Email = email;
            Message = message;
            Type = type;
            OwnerId = ownerId;
            ParentId = parrentId;
        }

        public Comment(string name, string email, string message, long type, long ownerId, long parrentId, bool isConfirmed)
        {
            Name = name;
            Email = email;
            Message = message;
            Type = type;
            OwnerId = ownerId;
            ParentId = parrentId;
            IsConfirmed = isConfirmed;
        }
        public void Confirmed()
        {
            IsConfirmed = true;
        }
        public void Cancled()
        {
            IsCancled = true;
        }
    }
}
