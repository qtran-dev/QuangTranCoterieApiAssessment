using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Coterie.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoterieBaseController : ControllerBase
    {
        private readonly IRatingService _service;

        public CoterieBaseController(IRatingService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<RatingResponse> GetRating(RatingRequest request)
        {
            try
            {
                RatingResponse response = _service.GetRatings(request);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}