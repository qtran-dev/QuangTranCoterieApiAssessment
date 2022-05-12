using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coterie.Api.Models.Requests
{
    public class RatingRequest
    {
        public string Business { get; set; }
        public decimal Revenue { get; set; }
        public List<string> States { get; set; }
    }
}
