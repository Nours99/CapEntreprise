using Dal.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs.Bottles;
using Models.DTOs.Users;

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
            List<UserGetDTO> usersDTO = new();

            foreach (User user in users)
            {
                usersDTO
                    .Add(new UserGetDTO
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

            UserGetDTO userDTO = new()
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

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsername([FromRoute] string username)
        {
            var user = await this.repository.GetUserByUsernameAsync(username);

            UserGetDTO userDTO = new()
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

            UserGetDTO userDTO = new()
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

            var user = await this.repository.GetUserByIDAsync(id);
            var bottles = await this.repository.GetUserWithBottlesAsync(id);
            List<BottleGetDTO> bottlesDTO = new();

            foreach (var bottle in bottles)
            {
                bottlesDTO
                    .Add(new BottleGetDTO
                    {
                        Id = bottle.Id,
                        Name = bottle.Name,
                        Color = bottle.Color,
                        Vintage = bottle.Vintage,
                        Location = bottle.Location
                    });
            }

            UserGetDTO userDTO = new()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Bottles = bottlesDTO
            };

            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserPostDTO userDTO)
        {
            User user = new User()
            {
                Username = userDTO.Username,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Birthday = userDTO.Birthday,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber
            };

            await repository.CreateUserAsync(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await repository.DeleteUserAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromBody] UserPostDTO userDTO)
        {
            User user = await repository.GetUserByIDAsync(id);

            user.Username = userDTO.Username;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Birthday = userDTO.Birthday;
            user.Email = userDTO.Email;
            user.PhoneNumber = userDTO.PhoneNumber;

            await repository.UpdateUserAsync(user);
            return Ok(user);
        }
    }
}
