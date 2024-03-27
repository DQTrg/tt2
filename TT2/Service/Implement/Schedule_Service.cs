using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest.Schedule;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Service.Implement
{
    public class Schedule_Service : ISchedule_Service
    {
        public readonly App_DBcontext _dbcontext;
        public readonly ResponseObject<DataResponse_Schedule> _response;
        public readonly ScheduleConverter _converter;
        public Schedule_Service()
        {
            _dbcontext = new App_DBcontext();
            _response = new ResponseObject<DataResponse_Schedule>();
            _converter = new ScheduleConverter();
        }
        public ResponseObject<DataResponse_Schedule> AddSchedule(Request_AddSchedule request)
        {
            if(string.IsNullOrWhiteSpace(request.Price.ToString()) || string.IsNullOrWhiteSpace(request.StartAt.ToString()) || 
               string.IsNullOrWhiteSpace(request.EndAt.ToString()) || string.IsNullOrEmpty(request.Code) || string.IsNullOrWhiteSpace(request.Name))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "nhap day du thong tin", null);
            }
            if(_dbcontext.Schedules.Any(x => x.Code == request.Code || x.Name == request.Name)) 
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "da ton tai", null);
            }
            var schedule = new Schedule()
            {
                Price = request.Price,
                StartAt = request.StartAt,
                EndAt = request.EndAt,
                Code = request.Code,
                Name = request.Name,
                MovieId = 1,
                RoomId = 1,
                IsActive = false,
            };
            if (_dbcontext.Schedules.Any(x => !((request.StartAt < x.StartAt && request.EndAt < x.StartAt) || (request.StartAt > x.EndAt && request.EndAt > x.EndAt)) && x.RoomId == request.RoomId))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "trung lich chieu", null);
            }
            _dbcontext.Schedules.Add(schedule);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("them thanh cong", _converter.EntityToDTO(schedule));
        }

        public ResponseObject<DataResponse_Schedule> DeleteSchedule(int scheduleId)
        {
            var schedule = _dbcontext.Schedules.SingleOrDefault(x => x.Id == scheduleId);
            if(schedule == null)
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "khong ton tai", null);
            }
            throw new NotImplementedException();
        }

        public ResponseObject<DataResponse_Schedule> UpdateSchedule(int scheduleId, Request_UpdateSchedule request)
        {
            throw new NotImplementedException();
        }
    }
}
