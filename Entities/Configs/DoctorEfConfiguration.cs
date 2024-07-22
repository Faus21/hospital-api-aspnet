using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task9.Entities.Configs
{
    public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor).HasName("Doctor_pk");

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();

            builder.ToTable("Doctor");

            Doctor[] doctors =
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Mykyta",
                    LastName = "Ushakov",
                    Email = "1234@gmail.com",

                }
            };

            builder.HasData(doctors);
        }
    }
}
