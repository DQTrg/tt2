using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest.Schedule;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class ScheduleController : Controller
    {
        public readonly ISchedule_Service _service;
        public ScheduleController(ISchedule_Service service)
        {
            _service = service;
        }
        [HttpPost("add_schedule")]
        public IActionResult AddSchedule([FromForm]Request_AddSchedule request)
        {
            return Ok(_service.AddSchedule(request));
        }
        [HttpPost("update_schedule")]
        public IActionResult UpdateSchedule(int scheduleId, [FromForm]Request_UpdateSchedule request)
        {
            return Ok(_service.UpdateSchedule(scheduleId, request));
        }
        [HttpPost("delete_schedule")]
        public IActionResult DeleteSchedule(int scheduleId)
        {
            return Ok(_service.DeleteSchedule(scheduleId));
        }
    }
}
