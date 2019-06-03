using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentOrderApi.Infrastructure.Settings
{
    public class ColourMapping
    {
        public string Key { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue {get; set; }
        public string[] Keywords { get; set; }
    }
}
