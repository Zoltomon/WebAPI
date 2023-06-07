using WebAPI.Classes.DTO;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Classes.POST
{
    public class UserPostClass:IUserPost
    {
        private readonly _1301123ZoltoContext _context;
        public UserPostClass(_1301123ZoltoContext context)
        {
            _context = context;
        }


        public bool CreateNote(UserDTO userDTO)
        {
            try
            {
                string hashPass = BCrypt.Net.BCrypt.HashPassword(userDTO.UserPassword);
                if (hashPass != null)
                {
                    var createUser = new Models.User
                    {
                        Login = userDTO.UserLogin,
                        Password = hashPass,
                        RoleId = 1,
                        StatusId = 1,


                    };

                    _context.Users.Add(createUser);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Results.BadRequest(ex);
                throw;
            }
        }

    }
}
