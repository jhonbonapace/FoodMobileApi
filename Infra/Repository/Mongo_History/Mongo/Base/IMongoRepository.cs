// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace Infra.Repository.Mongo.Base
// {
//     public interface IMongoRepository<TEntity> : IDisposable where TEntity : class
// {
//     Task Add(TEntity obj);
//     Task<TEntity> GetById(Guid id);
//     Task<IEnumerable<TEntity>> GetAll();
//     Task Update(TEntity obj);
//     Task Remove(Guid id);
// }
// }