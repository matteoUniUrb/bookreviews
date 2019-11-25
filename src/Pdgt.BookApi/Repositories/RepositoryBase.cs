using LiteDB;
using Pdgt.BookApi.Repositories;

namespace Pdgt.BookApi.Repositories
{

    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private readonly string _databaseFilename;

        public RepositoryBase(string databaseFilename)
        {
            _databaseFilename = databaseFilename;
        }

        public virtual T Get(string entityId)
        {
            using (var db = new LiteDatabase(_databaseFilename))
            {
                var entities = db.GetCollection<T>();
                return entities.FindById(entityId);
            }
        }

        public virtual void Add(T entity)
        {
            using (var db = new LiteDatabase(_databaseFilename))
            {
                var entities = db.GetCollection<T>();
                entities.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var db = new LiteDatabase(_databaseFilename))
            {
                var entities = db.GetCollection<T>();

                entities.Update(entity);
                return true;
            }
        }
    }
}