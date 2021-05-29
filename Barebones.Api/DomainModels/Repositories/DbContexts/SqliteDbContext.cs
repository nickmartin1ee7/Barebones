using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Barebones.Api.DomainModels.Repositories.DbContexts
{
    public class SqliteDbContext<TKey, TModel> : DbContext, IRepository<TModel>
        where TModel : DataModel<TKey, byte[]>
    {
        protected virtual DbSet<TModel> DbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlite($@"DataSource={nameof(Barebones)}.db", o =>
                    {
                        o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TModel>()
                .HasKey(x => x.Key);
        }

        public IEnumerable<TModel> GetAll() => DbSet.Local;

        public TModel Get(params object[] keys) =>
            DbSet.Find(keys);

        public TModel Create(TModel model) =>
            DbSet.Add(model).Entity;

        public TModel Update(TModel model) =>
            DbSet.Update(model).Entity;

        public TModel Delete(TModel model) =>
            DbSet.Remove(model).Entity;
    }
}