using MongoDB.Bson;
using Questionnaire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Questionnaire.Data.Repositories
{
    public interface IMongoRepository<TEntity>
        where TEntity : IEntity
    {
        Task<TEntity> GetByIdAsync(ObjectId id);

        Task<TEntity> SaveAsync(TEntity entity);

        Task<long> DeleteAsync(ObjectId id);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
