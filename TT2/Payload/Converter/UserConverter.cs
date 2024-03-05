using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class UserConverter
    {
        public readonly App_DBcontext dbcontext;
        public UserConverter() { 
        dbcontext = new App_DBcontext();
        }
        public DataResponse_User EntityToDTO(User user)
        {
            return new DataResponse_User()
            {
                Username = user.Username,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
            };
        }
    }
}
