namespace Task9.Entities

{
    public class Medicament
    {
        public int IdMedicament { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public virtual ICollection<MedicamentPrescription> MedicamentPrescriptions { get; set; } = new List<MedicamentPrescription>();
    }
}
