using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class RoomConverter
    {
        public readonly App_DBcontext dbcontext;
        public RoomConverter() 
        { 
            dbcontext = new App_DBcontext();
        }
        public DataResponse_Room EntityToDTO(Room room)
        {
            return new DataResponse_Room
            {
                Capacity = room.Capacity,
                Type = room.Type,
                Description = room.Description,
                Code = room.Code,
                Name = room.Name,
            };
        }
    }
}
