using Microsoft.AspNetCore.Mvc;
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
        //public IActionResult AddCinema()
    }
}
