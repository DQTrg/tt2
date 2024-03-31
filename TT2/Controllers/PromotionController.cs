using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest.Promotion;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    [ApiController]
    public class PromotionController : Controller
    {
        private readonly IPromotion_Service _service;
        public PromotionController(IPromotion_Service service)
        {
            _service = service;
        }
        [HttpPost("add_promotion")]
        public IActionResult AddPromotion(Request_AddPromotion request)
        {
            return Ok(_service.AddPromotion(request));
        }
        [HttpPost("update_promotion")]
        public IActionResult UpdatePromotion(int promotionId, Request_UpdatePromotion request)
        {
            return Ok(_service?.UpdatePromotion(promotionId, request));
        }
        [HttpGet("get_all_promotion")]
        public IActionResult GetAllPromotion()
        {
            return Ok(_service.GetAllPromotion());
        }
    }
}
