using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool Add(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(int id)
        {
            _context.Remove(id);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.users.ToListAsync(); 
        }

        public async Task<User> GetById(int id)
        {
            return await _context.users.FirstOrDefaultAsync(i => i.Id == id); 
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
