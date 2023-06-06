using WebAPI.Classes.DTO;
using WebAPI.Classes;

namespace WebAPI.Interface
{
    public interface InterfaceUser
    {
        public List<UserDTO> FirstOfDefault(string UserLogin, string UserPassword);
    }
}
