using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class SeatConverter
    {
        public readonly App_DBcontext dbcontext;
        public SeatConverter()
        {
            dbcontext = new App_DBcontext();
        }
        public DataResponse_Seat EntityToDTO(Seat seat)
        {
            return new DataResponse_Seat
            {
                Number = seat.Number,
                Line = seat.Line,
            };
        }
    }
}
