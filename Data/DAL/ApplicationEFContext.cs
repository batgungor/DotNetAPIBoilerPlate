using DotNetCoreAPIBoilerPlate.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DotNetCoreAPIBoilerPlate.Data.DAL
{
    public class ApplicationEFContext : DbContext
    {
        public ApplicationEFContext(DbContextOptions<ApplicationEFContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var baseEntityType = typeof(BaseEntity);
            var entitiesAssembly = baseEntityType.Assembly;
            var allTypes = entitiesAssembly.GetTypes();
            var entities = allTypes.Where(q => q.BaseType == baseEntityType && q != baseEntityType).ToList();
            foreach (var entityType in entities)
            {
                UseAsEntity(modelBuilder, entityType);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        private static void UseAsEntity(ModelBuilder modelBuilder, Type type)
        {
            modelBuilder.Entity(type);
        }
    }
}
