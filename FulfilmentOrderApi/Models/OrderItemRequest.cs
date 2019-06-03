namespace FulfilmentOrderApi.Models
{
    public class OrderItemRequest
    {
        public string Url { get; set; }
        public  string Sku { get; set; }
        public  int Copies { get; set; }
    }
}
