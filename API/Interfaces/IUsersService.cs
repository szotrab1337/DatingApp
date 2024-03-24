using API.Entities;

namespace API.Interfaces
{
    public interface IUsersService
    {
        Task<AppUser> Get(int userId);
        Task<IEnumerable<AppUser>> GetAll();
    }
}