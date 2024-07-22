using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task9.Entities.Configs
{
    public class MedicamentPrescriptionEfConfiguration : IEntityTypeConfiguration<MedicamentPrescription>
    {
        public void Configure(EntityTypeBuilder<MedicamentPrescription> builder)
        {
            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("MedicamentPrescription_pk");

            builder.Property(e => e.Dose);
            builder.Property(e => e.Decscription).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Medicament)
                .WithMany(e => e.MedicamentPrescriptions)
                .HasForeignKey(e => e.IdMedicament)
                .HasConstraintName("MedicamentPrescription_Medicament")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Prescription)
                .WithMany(e => e.MedicamentPrescriptions)
                .HasForeignKey(e => e.IdPrescription)
                .HasConstraintName("MedicamentPrescription_Prescription")
                .OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("Medicament_Prescription");

            MedicamentPrescription[] medicamentPrescriptions =
            {
                new MedicamentPrescription()
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 10,
                    Decscription = "Desc_1"
                },
                new MedicamentPrescription()
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Dose = 3,
                    Decscription = "Desc_2"
                }
            };

            builder.HasData(medicamentPrescriptions);
        } 
    }
}
