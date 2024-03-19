using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Service.Implement
{
    public class Room_Service : IRoom_Service
    {
        public readonly App_DBcontext _dbcontext;
        public readonly ResponseObject<DataResponse_Room> _response;
        public readonly RoomConverter _converter;
        public Room_Service()
        {
            _dbcontext = new App_DBcontext();
            _response = new ResponseObject<DataResponse_Room>();
            _converter = new RoomConverter();
        }
        public ResponseObject<DataResponse_Room> AddRoom(Request_AddRoom request)
        {
            if(string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Capacity.ToString()) || string.IsNullOrWhiteSpace(request.Code)
                || string.IsNullOrWhiteSpace(request.Description) || string.IsNullOrWhiteSpace(request.Type.ToString()))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "nhap day du thong tin", null);
            }
            if(_dbcontext.Rooms.Any(x => x.Name == request.Name || x.Code == request.Code))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "da ton tai", null);
            }
            var room = new Room()
            {
                Capacity = request.Capacity,
                Type = request.Type,
                Name = request.Name,
                Code = request.Code,
                Description = request.Description,
                CinemaId = 1,
                IsActive = false,
            };
            _dbcontext.Add(room);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("them thanh cong", _converter.EntityToDTO(room));
        }

        public ResponseObject<DataResponse_Room> DeleteRoom(int roomId)
        {
            var room = _dbcontext.Rooms.SingleOrDefault(x => x.Id == roomId);
            if(room == null)
            {
                return _response.ResponeError(StatusCodes.Status404NotFound, "khong tim thay phong chieu", null);
            }
            _dbcontext.Rooms.Remove(room);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("xoa thanh cong", _converter.EntityToDTO(room));
        }

        public ResponseObject<DataResponse_Room> UpdateRoom(int roomId, Request_UpdateRoom request)
        {
            var room = _dbcontext.Rooms.SingleOrDefault(x => x.Id == roomId);
            if (room == null)
            {
                return _response.ResponeError(StatusCodes.Status404NotFound, "khong tim thay phong chieu", null);
            }
            room.Capacity = request.Capacity;
            room.Type = request.Type;
            room.Name = request.Name;
            room.Code = request.Code;
            room.Description = request.Description;
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("cap nhat thanh cong", _converter.EntityToDTO(room));
        }
    }
}
