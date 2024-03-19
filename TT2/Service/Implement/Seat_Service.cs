using System.Runtime.InteropServices;
using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Service.Implement
{
    public class Seat_Service : ISeat_Service
    {
        public readonly App_DBcontext _dbcontext;
        public readonly ResponseObject<DataResponse_Seat> _response;
        public readonly SeatConverter _converter;
        public Seat_Service()
        {
            _dbcontext = new App_DBcontext();
            _response = new ResponseObject<DataResponse_Seat>();
            _converter = new SeatConverter();
        }
        public ResponseObject<DataResponse_Seat> AddSeat(Request_AddSeat request)
        {
            if(string.IsNullOrWhiteSpace(request.Number.ToString()) || string.IsNullOrEmpty(request.Line))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "nhap day du thong tin", null);
            }
            if(_dbcontext.Seats.Any(x => x.Number == request.Number))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "da ton tai", null);
            }
            var seat = new Seat()
            {
                Number = request.Number,
                Line = request.Line,
                SeatStatusId = 1,
                SeatTypeId = 1,
                RoomId = 1,
                TicketId = 1,
                IsActive = true,
            };
            _dbcontext.Seats.Add(seat);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("them thanh cong", _converter.EntityToDTO(seat));
        }

        public ResponseObject<DataResponse_Seat> DeleteSeat(int seatId)
        {
            var seat = _dbcontext.Seats.SingleOrDefault(x => x.Id == seatId);
            if(seat == null)
            {
                return _response.ResponeError(StatusCodes.Status404NotFound, "khong tim thay ghe", null);
            }
            _dbcontext.Seats.Remove(seat);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("xoa thanh cong", _converter.EntityToDTO(seat));
        }

        public ResponseObject<DataResponse_Seat> UpdateSeat(int seatId, Request_UpdateSeat request)
        {
            var seat = _dbcontext.Seats.SingleOrDefault(x => x.Id == seatId);
            if(seat == null)
            {
                return _response.ResponeError(StatusCodes.Status404NotFound, "khong tim thay ghe", null);
            }
            seat.Number = request.Number;
            seat.Line = request.Line;
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("sua thanh cong", _converter.EntityToDTO(seat));
        }
    }
}
