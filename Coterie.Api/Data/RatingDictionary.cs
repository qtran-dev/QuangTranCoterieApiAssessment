using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coterie.Api.Data
{
    public static class RatingDictionary
    {
        public static IReadOnlyDictionary<string, string> AbbreviationToState = new Dictionary<string, string>()
        {
            { "OH", "OHIO" },
            { "FL", "FLORIDA" },
            { "TX", "TEXAS" }
        };

        public static IReadOnlyDictionary<string, string> StateToAbbreviation = new Dictionary<string, string>()
        {
            { "OHIO", "OH" },
            { "FLORIDA", "FL" },
            { "TEXAS", "TX" }
        };

        public static IReadOnlyDictionary<string, decimal> StateFactors = new Dictionary<string, decimal>()
        {
            { "OH", 1.0m },
            { "FL", 1.2m },
            { "TX", 0.943m }
        };

        public static IReadOnlyDictionary<string, decimal> BusinessFactors = new Dictionary<string, decimal>()
        {
            { "Architect", 1.0m },
            { "Plumber", 0.5m },
            { "Programmer", 1.25m }
        };
    }
}
