using Dal.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs.User;

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
            var users = await this.repository.GetUsersAsync();
            List<GetUserDTO> usersDTO = new();

            foreach (User user in users)
            {
                usersDTO
                    .Add(new GetUserDTO
                    {
                        Id = user.Id,
                        Username = user.Username,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Birthday = user.Birthday,
                        PhoneNumber = user.PhoneNumber
                    });
            }

            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var user = await this.repository.GetUserByIDAsync(id);

            GetUserDTO userDTO = new() { 
                Id = user.Id,
                Username= user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber
            };
            return Ok(userDTO);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsername([FromRoute] string username)
        {
            var user = await this.repository.GetUserByUsernameAsync(username);

            GetUserDTO userDTO = new()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber
            };
            return Ok(userDTO);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail([FromRoute] string email)
        {
            var user = await this.repository.GetUserByEmailAsync(email);

            GetUserDTO userDTO = new()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber
            };
            return Ok(userDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserWithBottles(int id)
        {
            var bottles = await this.repository.GetUserWithBottlesAsync(id);
            var user = await this.repository.GetUserByIDAsync(id);

            GetUserDTO userDTO = new()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber,
                Bottles = bottles
            };
            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await repository.CreateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await repository.DeleteUserAsync(id);
            return Ok(repository.GetUserByIDAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await repository.UpdateUserAsync(user);
            return Ok(await repository.GetUserByIDAsync(user.Id));
        }
    }
}
