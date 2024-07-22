using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task9.Entities.Configs
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription).HasName("Prescription_pk");

            builder.HasOne(e => e.Patient).
                WithMany(e => e.Prescriptions).
                HasForeignKey(e => e.IdPatient)
                .HasConstraintName("Prescription_Patient")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Doctor).
                WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor)
                .HasConstraintName("Prescription_Doctor")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Date).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DueDate).IsRequired();

            builder.ToTable("Prescription");

            Prescription[] prescriptions =
            {
                new Prescription
                {
                    IdPrescription = 1,
                    DueDate = DateTime.UtcNow.AddDays(10),
                    IdDoctor = 1,
                    IdPatient = 1
                },

                new Prescription
                {
                    IdPrescription = 2,
                    DueDate = DateTime.UtcNow.AddDays(10),
                    IdDoctor = 3,
                    IdPatient = 1
                }
            };

            builder.HasData(prescriptions);
        }
    }
}
