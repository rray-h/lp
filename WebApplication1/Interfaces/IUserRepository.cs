using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        bool Add (User user);  
        bool Update (User user);
        bool Delete (int id);
        bool Save();

    }
}
