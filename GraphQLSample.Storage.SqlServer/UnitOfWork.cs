using GraphQLSample.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQLSample.Storage.SqlServer
{
    public class UnitOfWork<TDbContext> : IUnitOfWork, IScope where TDbContext : DbContext
    {
        private readonly TDbContext _context;
        private bool _committed;

        public UnitOfWork(TDbContext context)
        {
            _context = context;
        }

        public IScope Begin()
        {
            _committed = false;
            return this;
        }

        public void Commit()
        {
            _context.SaveChanges();
            _committed = true;
        }

        public void Rollback()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (!_committed)
            {
                Rollback();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
