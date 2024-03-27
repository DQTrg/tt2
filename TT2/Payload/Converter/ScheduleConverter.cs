using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class ScheduleConverter
    {
        public readonly App_DBcontext dbcontext;
        public ScheduleConverter()
        {
            dbcontext = new App_DBcontext();
        }
        public DataResponse_Schedule EntityToDTO(Schedule schedule)
        {
            return new DataResponse_Schedule()
            {
                Price = schedule.Price,
                StartAt = schedule.StartAt,
                EndAt = schedule.EndAt,
                Code = schedule.Code,
                Name = schedule.Name,
            };
        }
    }
}
