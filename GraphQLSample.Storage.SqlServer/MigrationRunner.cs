using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Storage.SqlServer
{
    public class MigrationsRunner<TDbContext> : IMigrationsRunner where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public MigrationsRunner(TDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.Migrate();
        }
    }
}
