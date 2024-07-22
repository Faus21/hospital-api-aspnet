namespace Task9.Models.DTO
{
    public class PrescriptionDTO
    {
        public int IdPrescription { get; init; }

        public DateTime Date { get; init; }

        public DateTime DueDate { get; init; }

        public DoctorDTO Doctor { get; init; }

        public PatientDTO Patient { get; init; }

        public List<MedicamentDTO> Medicaments { get; init; } 
    }
}
