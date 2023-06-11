using Microsoft.AspNetCore.Mvc;
using WebAPI.Classes.DTO;
using WebAPI.Models;
using WebAPI.Interface;

namespace WebAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
      
        private readonly IUser _users;
        public UserController(IUser users)
        {
            _users = users;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get(string UserLogin, string UserPassword) => await Task.FromResult(_users.FirstOfDefault(UserLogin, UserPassword));
    }
}

