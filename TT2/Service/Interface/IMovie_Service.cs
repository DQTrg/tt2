using TT2.Payload.DataRequest.Movie;
using TT2.Payload.DataResponse;
using TT2.Payload.Response;

namespace TT2.Service.Interface
{
    public interface IMovie_Service
    {
        ResponseObject<DataResponse_Movie> AddMovie(Request_AddMovie request);
        ResponseObject<DataResponse_Movie> UpdateMovie(int movieId, Request_UpdateMovie request);
        ResponseObject<DataResponse_Movie> DeleteMovie(int movieId);
    }
}
