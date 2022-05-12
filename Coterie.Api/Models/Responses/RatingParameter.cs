using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coterie.Api.Models.Responses
{
    public class RatingParameter
    {
        public decimal Revenue { get; set; }
        public decimal Premium { get; set; }
        public string Business { get; set; }
        public string State { get; set; }
    }
}
