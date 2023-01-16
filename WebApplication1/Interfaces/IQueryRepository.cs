using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IQueryRepository
    {
        Task<IEnumerable<Query>> GetAll();
        Task<List<Query>> GetAllbyUserID();
        Task<Query> GetById(int id);
        Task<Query> GetByIdNoTracking(int id);
        bool Add(Query query);
        bool Update(Query query);
        bool Delete(Query query);
        bool Save();

    }
}

