using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly ICinema_Service _service;
        public CinemaController(ICinema_Service service)
        {
            _service = service;
        }
        [HttpPost("api/service/add_cinema")]
        [Authorize(Roles = "admin")]
        public IActionResult AddCinema([FromForm] Request_AddCinema request_Add)
        {
            return Ok(_service.AddCinema(request_Add));
        }
    }
}
