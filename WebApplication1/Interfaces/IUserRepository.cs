using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAppUsers();
        Task<AppUser> GetById(string id);
        bool Delete (AppUser user);
        bool Save();
    }
}
