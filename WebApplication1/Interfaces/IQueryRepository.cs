using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IQueryRepository
    {
        Task<IEnumerable<Query>> GetAll();
        Task<Query> GetById(int id);
        bool Add(Query query);
        bool Update(Query query);
        bool Delete(int id);
        bool Save();

    }
}

