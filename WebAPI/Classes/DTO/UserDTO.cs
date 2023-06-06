using WebAPI.Models;

namespace WebAPI.Classes.DTO
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public virtual Role? IdRole { get; set; }

        public virtual Status? IdStatus { get; set; }
    }
}
