namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Domain.Common;
    using System.Linq;

    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(CarRentalDbContext db) => this.Data = db;

        protected CarRentalDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();
    }
}
