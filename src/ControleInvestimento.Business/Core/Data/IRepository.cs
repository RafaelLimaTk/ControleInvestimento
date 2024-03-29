﻿using ControleInvestimento.Business.Core.Models;
using System.Linq.Expressions;

namespace ControleInvestimento.Business.Core.Data;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Add(TEntity entity);
    Task<TEntity> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    Task Update(TEntity entity);
    Task Remove(Guid id);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}
