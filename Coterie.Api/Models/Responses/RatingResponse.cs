using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coterie.Api.Models.Responses
{
    public class RatingResponse : BaseSuccessResponse
    {
        public RatingResponse()
        {
            Premiums = new();
        }

        public string Business { get; set; }
        public decimal Revenue { get; set; }
        public List<StatePremium> Premiums { get; set; }
    }
}
