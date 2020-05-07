using GraphQLSample.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLSample.Storage.SqlServer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName);
            builder.Property(e => e.LastName);
            builder.Property(e => e.Email);
            builder.Property(e => e.WeightLbs);
            builder.Property(e => e.Birthday);
            builder.Metadata.FindNavigation(nameof(User.Books)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
