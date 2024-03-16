using TT2.Entity;
using TT2.Payload.Converter;
using TT2.Payload.DataRequest;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;
using TT2.Service.Interface;

namespace TT2.Service.Implement
{
    public class Movie_Service : IMovie_Service
    {
        public readonly App_DBcontext _dbcontext;
        public readonly ResponseObject<DataResponse_Movie> _response;
        public readonly MovieConverter _converter;
        public Movie_Service()
        {
            _converter = new MovieConverter();
            _dbcontext = new App_DBcontext();
            _response = new ResponseObject<DataResponse_Movie>();
        }
        public ResponseObject<DataResponse_Movie> AddMovie(Request_AddMovie request)
        {
            if(string.IsNullOrWhiteSpace(request.Language) || string.IsNullOrWhiteSpace(request.Director) ||
               string.IsNullOrWhiteSpace(request.MovieDuration.ToString()) || string.IsNullOrWhiteSpace(request.Name) ||
               string.IsNullOrWhiteSpace(request.Description) || string.IsNullOrWhiteSpace(request.Image) ||
               string.IsNullOrWhiteSpace(request.HeroImage) || string.IsNullOrWhiteSpace(request.Trailer) ||
               string.IsNullOrWhiteSpace(request.EndTime.ToString()) || string.IsNullOrWhiteSpace(request.PremierDate.ToString()))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "nhap day du thong tin", null);
            }
            if(_dbcontext.Movies.Any(x => x.Name == request.Name || x.Image == request.Image || x.Trailer == request.Trailer))
            {
                return _response.ResponeError(StatusCodes.Status400BadRequest, "da ton tai", null);
            }
            var movie = new Movie()
            {
                MovieDuration = request.MovieDuration,
                EndTime = request.EndTime,
                PremierDate = request.PremierDate,
                Description = request.Description,
                Director = request.Director,
                Image = request.Image,
                HeroImage = request.HeroImage,
                Language = request.Language,
                Name = request.Name,
                Trailer = request.Trailer,
                MovieTypeId = 1,
                RateId = 1,
                IsActive = false,
            };
            _dbcontext.Movies.Add(movie);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("them thanh cong", _converter.EntityToDTO(movie));
        }

        public ResponseObject<DataResponse_Movie> DeleteMovie(int movieId)
        {
            var movie = _dbcontext.Movies.SingleOrDefault(x => x.Id == movieId);
            if (movie == null)
            {
                return _response.ResponeError(StatusCodes.Status404NotFound, "khong tim thay phim", null);
            }
            _dbcontext.Movies.Remove(movie);
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("xoa thanh cong", _converter.EntityToDTO(movie));
        }

        public ResponseObject<DataResponse_Movie> UpdateMovie(int movieId, Request_UpdateMovie request)
        {
            var movie = _dbcontext.Movies.SingleOrDefault(x => x.Id == movieId);
            if (movie == null)
            {
                return _response.ResponeError(StatusCodes.Status404NotFound, "khong tim thay phim", null);
            }
            movie.MovieDuration = request.MovieDuration;
            movie.EndTime = request.EndTime;
            movie.PremierDate = request.PremierDate;
            movie.Description = request.Description;
            movie.Director = request.Director;
            movie.Image = request.Image;
            movie.HeroImage = request.HeroImage;
            movie.Language = request.Language;
            movie.Name = request.Name;
            movie.Trailer = request.Trailer;
            _dbcontext.SaveChanges();
            return _response.ResponseSucess("sua thanh cong", _converter.EntityToDTO(movie));
        }
    }
}
