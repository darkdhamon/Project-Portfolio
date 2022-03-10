namespace BHB.Common.API
{
    public class ApiResponse
    {
        private string _message;
        public Status Status { get; set; } = Status.Success;

        public string Message
        {
            get => _message??Status.ToString();
            set => _message = value;
        }
    }

    public class ApiResponse<T> :ApiResponse
    {
        public T Data { get; set; }
    }
}
