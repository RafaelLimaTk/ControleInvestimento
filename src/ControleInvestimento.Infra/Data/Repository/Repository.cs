using ControleInvestimento.Business.Core.Data;
using ControleInvestimento.Business.Core.Models;
using ControleInvestimento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleInvestimento.Infra.Data.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly ApplicationDbContext _applicationDbContext;
    protected readonly DbSet<TEntity> _entities;
    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _entities = _applicationDbContext.Set<TEntity>();
    }

    public async Task Add(TEntity entity)
    {
        _entities.Add(entity);
        await SaveChanges();
    }

    public void Dispose()
    {
        _applicationDbContext?.Dispose();
    }

    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _entities.ToListAsync();
    }

    public async Task<TEntity> GetById(Guid id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task Remove(Guid id)
    {
        _applicationDbContext.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await _applicationDbContext.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        _applicationDbContext.Entry(entity).State = EntityState.Modified;
        await SaveChanges();
    }
}
