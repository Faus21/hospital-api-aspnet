using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task9.Entities.Configs;

namespace Task9.Entities
{
    public class HospitalDbContex : DbContext
    {
        public virtual DbSet<Medicament> Medicaments { get; set; }

        public virtual DbSet<Prescription> Prescriptions { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<MedicamentPrescription> MedicamentPrescriptions { get; set; }

        public HospitalDbContex() { }

        public HospitalDbContex(DbContextOptions<HospitalDbContex> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
