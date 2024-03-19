using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface IFood_Service
    {
        ResponseObject<DataResponse_Food> AddFood(Request_AddFood request);
        ResponseObject<DataResponse_Food> UpdateFood(int foodId, Request_UpdateFood request);
        ResponseObject<DataResponse_Food> DeleteFood(int foodId);
    }
}
