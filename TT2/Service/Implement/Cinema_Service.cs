using Azure;
using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Service.Implement
{
    public class Cinema_Service : ICinema_Service
    {
        public readonly App_DBcontext _dbcontext;
        public readonly ResponseObject<DataResponse_Cinema> _response;
        public readonly CinemaConverter _converter;
        public Cinema_Service()
        {
            _dbcontext = new App_DBcontext();
            _response = new ResponseObject<DataResponse_Cinema>();
        }
        public ResponseObject<DataResponse_Cinema> AddCinema(Request_UpdateCinema request)
        {
            if (string.IsNullOrWhiteSpace(request.Address) || string.IsNullOrWhiteSpace(request.NameOfCinema) || string.IsNullOrWhiteSpace(request.Code))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "Vui long nhap day du thong tin", null);
            }
            if (_dbcontext.Cinemas.Any(x => x.Address == request.Address || x.NameOfCinema == request.NameOfCinema || x.Code == request.Code))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "Da ton tai", null);
            }
            var cinema = new Cinema
            {
                Address = request.Address,
                Description = request.Description,
                Code = request.Code,
                NameOfCinema = request.NameOfCinema,
                IsActive = false
            };
            _dbcontext.Add(cinema);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("Them thanh cong", _converter.EntityToDTO(cinema));
        }

        public ResponseObject<DataResponse_Cinema> DeleteCinema(int cinemaId)
        {
            throw new NotImplementedException();
        }

        public ResponseObject<DataResponse_Cinema> UpdateCinema(int cinemaId, Request_UpdateCinema request)
        {
            throw new NotImplementedException();
        }
    }
}
