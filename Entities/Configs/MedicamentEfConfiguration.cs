using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task9.Entities.Configs
{
    public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament).HasName("Medicament_pk");
            //entity.Property(e => e.IdMedicament).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Type).HasMaxLength(100).IsRequired();

            builder.ToTable("Medicament");

            Medicament[] medicaments =
            {
                new Medicament {IdMedicament = 1,
                    Name = "Med1",
                    Description = "Desc1",
                    Type = "Type1"
                },
                new Medicament {IdMedicament = 2,
                    Name = "Med2",
                    Description = "Desc2",
                    Type = "Type2"
                },
                new Medicament {IdMedicament = 3,
                    Name = "Med3",
                    Description = "Desc3",
                    Type = "Type3"
                }
              
            };

            builder.HasData(medicaments);
        }
    }
}
