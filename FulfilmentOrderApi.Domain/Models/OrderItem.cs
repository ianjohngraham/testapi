using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentOrderApi.Domain.Models
{
   public class OrderItem
   {
        public OrderItem(string sku, string url, int copies)
        {
            SKU = sku;
            Url = url;
            Copies = copies;
        }

        public string SKU { get; }
        public string Url { get; }
        public int Copies { get; }
    }
}

