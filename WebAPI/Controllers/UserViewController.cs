using Microsoft.AspNetCore.Mvc;
using WebAPI.Classes.DTO;
using WebAPI.Models;
using WebAPI.Interface;

namespace WebAPI.Controllers
{
    public class UserViewController : Controller
    {
      
        private readonly InterfaceUser _users;
        public UserViewController(InterfaceUser users)
        {
            _users = users;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get(string UserLogin, string UserPassword) => await Task.FromResult(_users.FirstOfDefault(UserLogin, UserPassword));
    }
}

