using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class FoodConverter
    {
        public readonly App_DBcontext dbcontext;
        public FoodConverter()
        {
            dbcontext = new App_DBcontext();
        }
        public DataResponse_Food EntityToDTO(Food food)
        {
            return new DataResponse_Food
            {
                Price = food.Price,
                Description = food.Description,
                Image = food.Image,
                NameOfFood = food.NameOfFood,
            };
        }
    }
}
