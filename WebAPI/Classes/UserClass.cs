using WebAPI.Classes.DTO;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Classes
{
    public class UserClass:IUser
    {
        private readonly _1301123ZoltoContext _context;
        public UserClass(_1301123ZoltoContext context)
        {
            _context = context;
        }

        public List<UserDTO> FirstOfDefault(string Login, string Password)
        {
            List<UserDTO> data = _context.Users
            .Select(
                        x => new UserDTO
                        {
                            UserLogin = x.Login,
                            UserPassword = x.Password,
                            Role = x.Role.NameRole,
                            Status = x.Status.NameStatus
                        }
                ).Where(u => u.UserLogin == Login && u.UserPassword == Password).ToList();

            if (data != null)
            {
                return data;

            }
            else
            {
                return new List<UserDTO>() {
                };
            }
        }

    }
}
