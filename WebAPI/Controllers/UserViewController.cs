using Microsoft.AspNetCore.Mvc;
using WebAPI.Classes.DTO;
using WebAPI.Models;
using WebAPI.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserViewController : Controller
    {
      
        private readonly IUser _users;
        public UserViewController(IUser users)
        {
            _users = users;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get(string UserLogin, string UserPassword) => await Task.FromResult(_users.FirstOfDefault(UserLogin, UserPassword));
    }
}

