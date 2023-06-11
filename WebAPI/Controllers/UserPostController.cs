using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Classes.DTO;
namespace WebAPI.Controllers
{
    [Route("api/UserPost")]
    [ApiController]

    public class UserPostController : Controller
    {
        private readonly IUserPost _IuserPost;
        public UserPostController(IUserPost IuserPost) => _IuserPost = IuserPost;


        [HttpPost("createNote")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Post(UserDTO userDTO)
        {
            if (!_IuserPost.CreateNote(userDTO))
            {
                await Request.ReadFormAsync();
                return NotFound();
            }
            return Ok();
        }

    }
}
