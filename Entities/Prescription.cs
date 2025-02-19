﻿namespace Task9.Entities
{
    public class Prescription
    {
        public int IdPrescription { get; set; }

        public DateTime Date { get;set; }

        public DateTime DueDate { get; set; }

        public int IdDoctor { get; set; }

        public int IdPatient { get; set; }

        public virtual ICollection<MedicamentPrescription> MedicamentPrescriptions { get; set; } = new List<MedicamentPrescription>();


        public virtual Doctor Doctor { get; set; } 

        public virtual Patient Patient { get; set; }

    }
}
