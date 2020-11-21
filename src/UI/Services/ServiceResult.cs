namespace ModernArchitectureShop.ShopUI.Services
{
    public class ServiceResult<T>
    {
        public int StatusCode { get; set; }

        public string Error { get; set; } = string.Empty;

        public T Content { get; set; } = default!;
    }
}
