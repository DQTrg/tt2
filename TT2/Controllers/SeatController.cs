using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest.Seat;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class SeatController : Controller
    {
        private readonly ISeat_Service _service;
        public SeatController(ISeat_Service service)
        {
            _service = service;
        }
        [HttpPost("add_seat")]
        public IActionResult AddSeat([FromForm] Request_AddSeat request)
        {
            return Ok(_service.AddSeat(request));
        }
        [HttpPut("update_seat")]
        public IActionResult UpdateSeat(int seatId, [FromForm] Request_UpdateSeat request)
        {
            return Ok(_service.UpdateSeat(seatId, request));
        }
        [HttpPut("delete_seat")]
        public IActionResult DeleteSeat(int seatId)
        {
            return Ok(_service.DeleteSeat(seatId));
        }
    }
}
