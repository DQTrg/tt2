using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class CinemaConverter
    {
        public readonly App_DBcontext dbcontext;
        public CinemaConverter()
        {
            dbcontext = new App_DBcontext();
        }
        public DataResponse_Cinema EntityToDTO(Cinema cinema)
        {
            return new DataResponse_Cinema()
            {
                Address = cinema.Address,
                Description = cinema.Description,
                Code = cinema.Code,
                NameOfCinema = cinema.NameOfCinema,
            };
        }
    }
}
