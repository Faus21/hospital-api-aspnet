using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task9.Entities.Configs
{
    public class UserEfConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.IdUser).HasName("User_pk");

            builder.Property(e => e.Login).IsRequired();
            builder.Property(e => e.Password).IsRequired();

            builder.Property(e => e.RefreshToken);
            builder.Property(e => e.ExpirationDate);

            builder.ToTable("User");
        }
    }
}
