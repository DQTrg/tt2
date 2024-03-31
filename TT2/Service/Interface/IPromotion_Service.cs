using TT2.Payload.DataRequest.Promotion;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface IPromotion_Service
    {
        ResponseObject<DataResponse_Promotion> AddPromotion(Request_AddPromotion request);
        ResponseObject<DataResponse_Promotion> UpdatePromotion(int promotionId, Request_UpdatePromotion request);
        IQueryable<DataResponse_Promotion> GetAllPromotion();
    }
}
