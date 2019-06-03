using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FulfilmentOrderApi.Models
{
    public class OrderRequest
    {
        public string OrderId { get; set; }
        public IEnumerable<OrderItemRequest> Items { get; set; }
    }
}
