using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class UserControler : Controller
    {
        private readonly IUser_Service _user_service;

        public UserControler(IUser_Service user_service)
        {
            _user_service = user_service;
        }
        [HttpPost("/api/auth/register")]
        public IActionResult register([FromForm] Request_register request_Register)
        {
            return Ok(_user_service.Register(request_Register));
        }
    }
}
