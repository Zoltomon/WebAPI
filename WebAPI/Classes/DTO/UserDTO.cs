using WebAPI.Models;

namespace WebAPI.Classes.DTO
{
    public class UserDTO
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}
