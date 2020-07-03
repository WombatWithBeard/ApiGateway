namespace Application.Common.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
    }
}