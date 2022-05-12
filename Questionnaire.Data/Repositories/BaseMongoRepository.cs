using MongoDB.Bson;
using MongoDB.Driver;
using Questionnaire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Questionnaire.Data.Repositories
{
    public abstract class BaseMongoRepository<TEntity> : IMongoRepository<TEntity>
        where TEntity : IEntity
    {
        protected abstract IMongoCollection<TEntity> Collection { get; }

        public async Task<long> DeleteAsync(ObjectId id)
        {
            var filter = new FilterDefinitionBuilder<TEntity>().Eq(a => a.Id, id);

            var res = await Collection.DeleteOneAsync(filter);

            return res.DeletedCount;
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var items = await Collection.Find(predicate).ToListAsync();

            return items;
        }

        public async Task<TEntity> GetByIdAsync(ObjectId id)
        {
            var item = await Collection.Find(a => a.Id.Equals(id)).FirstOrDefaultAsync();

            return item;
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            if (entity.Id == ObjectId.Empty)
            {
                entity.Id = ObjectId.GenerateNewId();
            }

            await Collection.ReplaceOneAsync
            (
                x => x.Id.Equals(entity.Id), 
                entity,
                new ReplaceOptions { IsUpsert = true }
            );

            return entity;
        }
    }
}