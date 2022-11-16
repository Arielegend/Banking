namespace SplitiT.Contracts
{
    public abstract class ResponseBase
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
