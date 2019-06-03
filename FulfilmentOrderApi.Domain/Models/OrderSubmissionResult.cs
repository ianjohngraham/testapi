using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentOrderApi.Domain.Models
{
    public class OrderSubmissionResult
    {
        public List<ColourMatch> ColourMatches { get; set; } = new List<ColourMatch>();
    }
}
