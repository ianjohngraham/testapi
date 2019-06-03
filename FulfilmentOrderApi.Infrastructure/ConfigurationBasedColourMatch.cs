using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            var colourMatches = new List<ColourMatch>();
            var colourMappingMatch = mappings.Mappings.FirstOrDefault(m => MatchesColour(url, m));

            if(colourMappingMatch != null)
            {
                return new ColourMatch(url, colourMappingMatch.Key);
            }
            return null;
        }

        private bool MatchesColour(string url, ColourMapping mapping)
        {
            string pattern = @"^.*\b(" + string.Join("|", mapping.Keywords.Select(k=> k.ToLower())) + @")\b.*$";
            return Regex.IsMatch(url.ToLower(), pattern, RegexOptions.Multiline);
        }
    }
}
