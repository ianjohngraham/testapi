using System.Collections.Generic;

namespace FulfilmentOrderApi.Domain.Models
{
    public interface IColourMatch
    {
        ColourMatch MatchColourFromUrl(string url);
    }
}