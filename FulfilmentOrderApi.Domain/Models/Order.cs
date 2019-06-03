using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FulfilmentOrderApi.Domain.Models
{
    public class Order
    {
        private List<OrderItem> _OrderItems = new List<OrderItem>();       
        public OrderSubmissionResult result = new OrderSubmissionResult();

        public Order(string orderId)
        {
            OrderId = orderId;
        }

        public string OrderId { get; }

        public void AddOrderItem(string sku, string url, int copies)
        {
            var orderItem = new OrderItem(sku, url, copies);
            _OrderItems.Add(orderItem);
        }

        public void Submit(IColourMatch colourMatch)
        {
            var submissionResult = new OrderSubmissionResult();
            foreach (var orderItem in this._OrderItems)
            {
                var match = colourMatch.MatchColourFromUrl(orderItem.Url);
                if(match == null)
                   continue;

                result.ColourMatches.Add(match);
            }
        }
    }
}
