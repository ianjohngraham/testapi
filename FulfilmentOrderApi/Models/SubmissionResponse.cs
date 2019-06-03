using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FulfilmentOrderApi.Domain.Models;

namespace FulfilmentOrderApi.Models
{
    public class SubmissionResponse
    {
        private readonly OrderSubmissionResult result;

        public SubmissionResponse(OrderSubmissionResult result)
        {
            this.result = result;
        }

        public IEnumerable<ColourMatch> ColourMatches => result.ColourMatches;
    }
}
