using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest.Movie;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovie_Service _service;
        public MovieController(IMovie_Service service)
        {
            _service = service;
        }
        [HttpPost("add_movie")]
        public IActionResult AddMovie([FromForm] Request_AddMovie request)
        {
            return Ok(_service.AddMovie(request));
        }
        [HttpPut("update_movie")]
        public IActionResult UpdateMovie(int movieId, [FromForm] Request_UpdateMovie request)
        {
            return Ok(_service.UpdateMovie(movieId, request));
        }
        [HttpPut("delete_movie")]
        public IActionResult DeleteMovie(int movieId)
        {
            return Ok(_service.DeleteMovie(movieId));
        }
    }
}
