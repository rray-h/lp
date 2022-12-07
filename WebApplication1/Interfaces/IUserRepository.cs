using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        bool add (User user);  
        bool update (User user);
        bool delete (int id);
        bool save();

    }
}
