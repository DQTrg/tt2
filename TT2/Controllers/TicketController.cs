using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest.Ticket;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicket_Service _service;
        public TicketController(ITicket_Service service)
        {
            _service = service;
        }
        [HttpPost("add_ticket")]
        public IActionResult AddTicket([FromForm] Request_AddTicket request)
        {
            return Ok(_service.AddTicket(request));
        }
        [HttpPost("update_ticket")]
        public IActionResult UpdateTicket(int ticketId, [FromForm] Request_UpdateTicket request)
        {
            return Ok(_service.UpdateTicket(ticketId, request));
        }
    }
}
