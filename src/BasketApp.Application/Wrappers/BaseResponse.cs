namespace BasketApp.Application.Wrappers
{
    public class BaseResponse
    {
        public string ErrorMessage { get; set; }

        public bool IsSuccess { get; set; } = true;
    }
}
