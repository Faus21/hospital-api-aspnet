using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task9.Entities.Configs
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient).HasName("Patient_pk");

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Birthdate).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.ToTable("Patient");

            Patient[] patients =
            {
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Andrii",
                    LastName = "Korovai"
                }
            };

            builder.HasData(patients);
        }
    }
}
