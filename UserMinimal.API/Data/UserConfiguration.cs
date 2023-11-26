using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMinimal.API.Models;

namespace UserMinimal.API.Data;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.Property(u => u.Name).IsRequired();

        builder.Property(u => u.Email).IsRequired();

        builder.Property(u => u.Age).IsRequired();
    }
}
