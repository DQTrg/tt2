using Microsoft.AspNetCore.Mvc;
using TT2.Payload.DataRequest.Food;
using TT2.Service.Interface;

namespace TT2.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFood_Service _service;
        public FoodController(IFood_Service service)
        {
            _service = service;
        }
        [HttpPost("add_food")]
        public IActionResult AddFood([FromForm] Request_AddFood request)
        {
            return Ok(_service.AddFood(request));
        }
        [HttpPut("update_food")]
        public IActionResult UpdateFood(int foodId, [FromForm] Request_UpdateFood request)
        {
            return Ok(_service.UpdateFood(foodId, request));
        }
        [HttpPut("delete_food")]
        public IActionResult DeleteFood(int foodId)
        {
            return Ok(_service.DeleteFood(foodId));
        }
    }
}
