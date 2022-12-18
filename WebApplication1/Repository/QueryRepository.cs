using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly ApplicationDBContext _context;
        public QueryRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool Add(Query query)
        {
            _context.Add(query);
            return Save();
        }

        public bool Delete(int id)
        {
            _context.Remove(id);
            return Save();
        }

        public async Task<IEnumerable<Query>> GetAll()
        {
            return await _context.query.ToListAsync();
        }

        public async Task<Query> GetById(int id)
        {
            return await _context.query.Include(i=> i.User).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Query Query)
        {
            throw new NotImplementedException();
        }
    }
}
