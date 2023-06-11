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
            User user = _context.Users.FirstOrDefault(u => u.Login == Login);

            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.Password))
            {
                List<UserDTO> data = _context.Users
                    .Where(u => u.Login == Login)
                    .Select(x => new UserDTO
                    {
                        UserLogin = x.Login,
                        UserPassword = x.Password,
                        Role = x.Role.NameRole,
                        Status = x.Status.NameStatus
                    })
                    .ToList();

                return data;
            }
            else
            {
                return new List<UserDTO>();
            }
        }

    }
}
