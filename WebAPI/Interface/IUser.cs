using WebAPI.Classes.DTO;
using WebAPI.Classes;

namespace WebAPI.Interface
{
    public interface IUser
    {
        public List<UserDTO> FirstOfDefault(string UserLogin, string UserPassword);
    }
}
