using TT2.Payload.DataRequest.Schedule;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface ISchedule_Service
    {
        ResponseObject<DataResponse_Schedule> AddSchedule(Request_AddSchedule request);
        ResponseObject<DataResponse_Schedule> UpdateSchedule(int scheduleId, Request_UpdateSchedule request);
        ResponseObject<DataResponse_Schedule> DeleteSchedule(int scheduleId);
    }
}
