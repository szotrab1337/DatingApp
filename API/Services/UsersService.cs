using API.Data;
using API.Entities;
using API.Exceptions;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UsersService(DataContext context) : IUsersService
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<AppUser> Get(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
            {
                throw new NotFoundException("User not found");
            }

            return user;
        }
    }
}
