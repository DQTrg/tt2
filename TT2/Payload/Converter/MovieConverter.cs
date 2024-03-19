using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class MovieConverter
    {
        public readonly App_DBcontext dbcontext;
        public MovieConverter() 
        {
            dbcontext = new App_DBcontext();
        }
        public DataResponse_Movie EntityToDTO(Movie movie)
        {
            return new DataResponse_Movie
            {
                MovieDuration = movie.MovieDuration,
                EndTime = movie.EndTime,
                PremierDate = movie.PremierDate,
                Description = movie.Description,
                Director = movie.Director,
                Image = movie.Image,
                HeroImage = movie.HeroImage,
                Language = movie.Language,
                Name = movie.Name,
                Trailer = movie.Trailer,
            };
        }
    }
}
