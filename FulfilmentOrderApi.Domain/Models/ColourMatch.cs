using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentOrderApi.Domain.Models
{
    public class ColourMatch
    {
        public ColourMatch(string url, string colour)
        {
            Url = url;
            Colour = colour;
        }

        public string Url { get; }
        public string Colour { get; }
    }
}
