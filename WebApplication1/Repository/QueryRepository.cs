using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public QueryRepository(ApplicationDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContext = httpContextAccessor;
        }
        public bool Add(Query query)
        {
            _context.Add(query);
            return Save();
        }

        public bool Delete(Query query)
        {
            _context.Remove(query);
            return Save();
        }

        public async Task<IEnumerable<Query>> GetAll()
        {
            return await _context.query.ToListAsync();
        }

        public async Task<List<Query>> GetAllbyUserID()
        {
            var curUser = _httpContext.HttpContext?.User.GetUserId();
            var userQueries = _context.query.Where(r => r.AppUser.Id == curUser);
            return userQueries.ToList();
        }
        public async Task<List<Query>> GetAllbyFreelancerName()
        {
            var curUser = _httpContext.HttpContext?.User.GetUserName();
            var userQueries = _context.query.Where(r => r.FreelancerID == curUser);
            return userQueries.ToList();
        }

        public async Task<Query> GetById(int id)
        {
            return await _context.query.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Query> GetByIdNoTracking(int id)
        {
            return await _context.query.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Query Query)
        {
            _context.Update(Query);
            return Save();
        }
    }
}
