using Pdgt.BookApi.Data;

namespace Pdgt.BookApi.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(string entityId);

        void Add(T entity);

        bool Update(T entity);
    }
}