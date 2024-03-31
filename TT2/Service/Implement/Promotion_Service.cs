using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest.Promotion;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Service.Implement
{
    public class Promotion_Service : IPromotion_Service
    {
        public readonly App_DBcontext _dbcontext;
        public readonly ResponseObject<DataResponse_Promotion> _response;
        public readonly PromotionConverter _converter;
        public Promotion_Service()
        {
            _converter = new PromotionConverter();
            _dbcontext = new App_DBcontext();
            _response = new ResponseObject<DataResponse_Promotion>();
        }
        public ResponseObject<DataResponse_Promotion> AddPromotion(Request_AddPromotion request)
        {
            var rank = _dbcontext.RankCustomers.SingleOrDefault(x => x.Id == request.RankCustomerId);
            if(rank == null)
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "khong ton tai", null);
            }
            var promotion = new Promotion()
            {
                Percent = request.Percent,
                Quantity = request.Quantity,
                Type = request.Type,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Description = request.Description,
                Name = request.Name,
                IsActive = false,
                RankCustomerId = request.RankCustomerId,
            };
            _dbcontext.Promotions.Add(promotion);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("them thanh cong", _converter.EntityToDTO(promotion));
        }

        public IQueryable<DataResponse_Promotion> GetAllPromotion()
        {
            var promotion = _dbcontext.Promotions.ToList();
            return promotion.Select(x => _converter.EntityToDTO(x)).AsQueryable();
        }

        public ResponseObject<DataResponse_Promotion> UpdatePromotion(int promotionId, Request_UpdatePromotion request)
        {
            var promotion = _dbcontext.Promotions.SingleOrDefault(x => x.Id == promotionId);
            if (promotion == null)
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "khong ton tai", null);
            }
            promotion.Percent = request.Percent;
            promotion.Type = request.Type;
            promotion.Quantity = request.Quantity;
            promotion.StartTime = request.StartTime;
            promotion.EndTime = request.EndTime;
            promotion.Description = request.Description;
            promotion.Name = request.Name;
            promotion.RankCustomerId = request.RankCustomerId;
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("cap nhat thanh cong", _converter.EntityToDTO(promotion));
        }
    }
}
