using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coterie.Api.Interfaces
{
    public interface IRatingService
    {
        RatingResponse GetRatings(RatingRequest request);
    }
}
