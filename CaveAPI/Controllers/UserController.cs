using Dal.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CaveAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserRepository repository;
        public UserController(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await this.repository.GetUsersAsync(); // REPOSITORY
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var user = await this.repository.GetUserByIDAsync(id);
            return Ok(user);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsername([FromRoute] string username)
        {
            var user = await this.repository.GetUserByUsernameAsync(username);
            return Ok(user);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail([FromRoute] string email)
        {
            var user = await this.repository.GetUserByEmailAsync(email);
            return Ok(user);
        }
    }
}
