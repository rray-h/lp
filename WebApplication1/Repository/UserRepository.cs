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
            _context= context;
        }
         
        public async Task<IEnumerable<AppUser>> GetAppUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public bool Delete(AppUser user)
        {
            throw new NotImplementedException();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }

        public async Task<AppUser> GetById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
