using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using FulfilmentOrderApi.Domain.Models;
using FulfilmentOrderApi.Infrastructure.Settings;

namespace FulfilmentOrderApi.Infrastructure
{
    public class ConfigurationBasedColourMatch : IColourMatch
    {
        private readonly ColourMatchMappings mappings;

        public ConfigurationBasedColourMatch(ColourMatchMappings mappings)
        {
            this.mappings = mappings;
        }

        public ColourMatch MatchColourFromUrl(string url)
        {
            using (WebClient wc = new WebClient())
            {
                using (Stream s = wc.OpenRead(url))
                {
                    using (Bitmap bmp = new Bitmap(s))
                    {
                        var colourMatches = new List<ColourMatch>();
                        var averageColour = GetAverageColour(bmp);

                        var colourMappingMatch = mappings.Mappings.FirstOrDefault(m => MatchesColour(averageColour, m));

                        if (colourMappingMatch != null)
                        {
                            return new ColourMatch(url, colourMappingMatch.Key);
                        }
                        return null;
                    }
                }
            }
           
          
        }

        private bool MatchesColour(Colour colour, ColourMapping mapping)
        {
            return mapping.Blue == colour.Blue && mapping.Red == colour.Red && mapping.Green == colour.Green;
        }



        public Colour GetAverageColour(Bitmap bmp)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);

                    r += clr.R * clr.R;
                    g += clr.G * clr.G;
                    b += clr.B * clr.B;

                    total++;
                }
            }
             
            r =Math.Sqrt(r / total);
            g =Math.Sqrt( g /total);
            b =Math.Sqrt( b /total);

            return  new Colour { Red =(int) r,  Green = (int)g, Blue = (int)b, }; 
        }
    }
}
