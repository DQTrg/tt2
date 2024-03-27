using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest.Room;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoom_Service _service;
        public RoomController(IRoom_Service service)
        {
            _service = service;
        }
        [HttpPost("add_room")]
        public IActionResult AddRoom([FromForm] Request_AddRoom request)
        {
            return Ok(_service.AddRoom(request));
        }
        [HttpPut("update_room")]
        public IActionResult UpdateRoom(int roomId, [FromForm] Request_UpdateRoom request)
        {
            return Ok(_service.UpdateRoom(roomId, request));
        }
        [HttpPut("delete_room")]
        public IActionResult DeleteRoom(int roomId)
        {
            return Ok(_service.DeleteRoom(roomId));
        }
    }
}
