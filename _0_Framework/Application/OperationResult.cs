namespace _0_Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSuccedded = true;
        }
        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد.")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }
        public OperationResult Failde(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
