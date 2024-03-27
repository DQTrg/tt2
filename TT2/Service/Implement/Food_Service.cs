using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest.Food;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Service.Implement
{
    public class Food_Service : IFood_Service
    {
        public readonly App_DBcontext _dbcontext;
        public readonly ResponseObject<DataResponse_Food> _response;
        public readonly FoodConverter _converter;
        public Food_Service()
        {
            _dbcontext = new App_DBcontext();
            _response = new ResponseObject<DataResponse_Food>();
            _converter = new FoodConverter();
        }
        public ResponseObject<DataResponse_Food> AddFood(Request_AddFood request)
        {
            if(string.IsNullOrWhiteSpace(request.Price.ToString()) || string.IsNullOrWhiteSpace(request.NameOfFood) || string.IsNullOrWhiteSpace(request.Description) || string.IsNullOrWhiteSpace(request.Image)) 
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "nhap day du thong tin", null);
            }
            if(_dbcontext.Foods.Any(x => x.NameOfFood == request.NameOfFood || x.Description == request.Description))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "da ton tai", null);
            }
            var food = new Food()
            {
                Price = request.Price,
                Description = request.Description,
                Image = request.Image,
                NameOfFood = request.NameOfFood,
                IsActive = false,
            };
            _dbcontext.Add(food);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("them thanh cong", _converter.EntityToDTO(food));
        }

        public ResponseObject<DataResponse_Food> DeleteFood(int foodId)
        {
            var food = _dbcontext.Foods.SingleOrDefault(x => x.Id == foodId);
            if (food == null)
            {
                return _response.ResponeError(StatusCodes.Status404NotFound, "khong tim thay thuc an", null);
            }
            _dbcontext.Foods.Remove(food);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("xoa thanh cong", _converter.EntityToDTO(food));
        }

        public ResponseObject<DataResponse_Food> UpdateFood(int foodId, Request_UpdateFood request)
        {
            var food = _dbcontext.Foods.SingleOrDefault(x => x.Id == foodId);
            if (food == null)
            {
                return _response.ResponeError(StatusCodes.Status404NotFound, "khong tim thay thuc an", null);
            }
            food.Price = request.Price;
            food.NameOfFood = request.NameOfFood;
            food.Description = request.Description;
            food.Image = request.Image;
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("cap nhat thanh cong", _converter.EntityToDTO(food));
        }
    }
}
