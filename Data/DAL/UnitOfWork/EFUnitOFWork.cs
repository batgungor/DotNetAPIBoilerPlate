using DotNetCoreAPIBoilerPlate.Data.DAL.Repository;
using DotNetCoreAPIBoilerPlate.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreAPIBoilerPlate.Data.DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool _isDisposed = false;
        private readonly ApplicationEFContext _context;
        private Dictionary<Type, object> _repositories;
        public EFUnitOfWork(ApplicationEFContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            EFRepository<TEntity> repository;
            var repositoryAlreadyCreated = _repositories.ContainsKey(typeof(TEntity));
            if (repositoryAlreadyCreated)
            {
                repository = (EFRepository<TEntity>)_repositories.Where(q => q.Key == typeof(TEntity)).FirstOrDefault().Value;
            }
            else
            {
                repository = new EFRepository<TEntity>(_context);
                _repositories.Add(typeof(TEntity), repository);
            }
            return repository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (this._isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}