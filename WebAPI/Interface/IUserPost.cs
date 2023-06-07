using WebAPI.Classes.DTO;

namespace WebAPI.Interface
{
    public interface IUserPost
    {
        public bool CreateNote(UserDTO userDTO);
    }
}
