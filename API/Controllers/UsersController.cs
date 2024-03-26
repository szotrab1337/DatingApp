using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController(IUsersService usersService) : BaseApiController
    {
        private readonly IUsersService _usersService = usersService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _usersService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")] // api/users/2
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _usersService.Get(id);
        }
    }
}
