using DotNetCoreAPIBoilerPlate.Data.DAL.Repository;
using DotNetCoreAPIBoilerPlate.Data.Entities;
using System;

namespace DotNetCoreAPIBoilerPlate.Data.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
