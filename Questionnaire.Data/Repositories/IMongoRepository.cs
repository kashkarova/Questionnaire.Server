using Questionnaire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Questionnaire.Data.Repositories
{
    public interface IMongoRepository<TEntity, in TKey> where TEntity : IEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);

        Task<TEntity> SaveAsync(TEntity entity);

        Task<long> DeleteAsync(TKey id);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
