using GraphQLSample.Core.Domains;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQLSample.Storage.SqlServer
{
    public class BoundaryDbContext : DbContext
    {
        public BoundaryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Seed(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User("Alper", "Ebicoglu", "alperEb@hotmail.com", 198, new DateTime(1985, 5, 8)) { Id = 1 });
            builder.Entity<User>().HasData(new User("Bob", "Burgers", "bobbo@burgers.com", 145, new DateTime(1962, 12, 30)) { Id = 2 });
            builder.Entity<User>().HasData(new User("Tim", "Farris", "Tarris@yahoo.com", 184, new DateTime(1937, 6, 27)) { Id = 3 });
            builder.Entity<User>().HasData(new User("Jody", "Stevenson", "jodyS@gmail.com", 173, new DateTime(1953, 2, 18)) { Id = 4 });
            builder.Entity<User>().HasData(new User("Michael", "Scott", "scott@dunder.com", 160, new DateTime(1999, 11, 5)) { Id = 5 });
        }
    }
}
