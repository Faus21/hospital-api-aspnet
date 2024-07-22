namespace Task9.Entities
{
    public class MedicamentPrescription
    {
        public int IdMedicament { get; set; }

        public int IdPrescription { get; set; }
        public int Dose { get; set; }

        public string Decscription { get; set;}

        public virtual Medicament Medicament { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
