using Microsoft.EntityFrameworkCore;
using Task9.Entities;
using Task9.Models.DTO;

namespace Task9.Service
{
    public class HospitalDbService : IHospitalDbService
    {
        private readonly HospitalDbContex _context;
        public HospitalDbService(HospitalDbContex hospitalDbContex) {
            _context = hospitalDbContex;
        }


        public async Task<ResultDTO<string>> DeleteDoctorAsync(int IdDoctor)
        {
            Doctor doctor =  await _context.Doctors.Where(e => e.IdDoctor == IdDoctor).FirstOrDefaultAsync();

            if (doctor == null)
            {
                return new ResultDTO<string>
                {
                    Result = "Not the same id!",
                    Code = 404
                };
            }

            List<Prescription> prescriptions = await _context.Prescriptions.Where(e => e.IdDoctor == doctor.IdDoctor).ToListAsync();

            foreach (var prescription in prescriptions)
            {
                List<MedicamentPrescription> mp = await _context.MedicamentPrescriptions.Where(e => e.IdPrescription == prescription.IdPrescription).ToListAsync();
                _context.MedicamentPrescriptions.RemoveRange(mp);
            }

            _context.Prescriptions.RemoveRange(prescriptions);

            _context.Doctors.Remove(doctor);

            await _context.SaveChangesAsync();

            return new ResultDTO<string>
            {
                Result = "Ok!",
                Code = 200
            };
        }

        public ResultDTO<DoctorDTO> GetDoctor(int IdDoctor)
        {
            return new ResultDTO<DoctorDTO>
            {
                Result = _context.Doctors.Where(e => e.IdDoctor == IdDoctor).Select(e => 
                new DoctorDTO
                {
                    IdDoctor = e.IdDoctor,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email
                }).FirstOrDefault(),
                Code = 200
            };
        }

        public ResultDTO<PrescriptionDTO> GetPrescription(int IdPrescription)
        {
            DoctorDTO doctor = _context.Prescriptions
                .Where(e => e.IdPrescription == IdPrescription)
                .Include(e => e.Doctor)
                .Select(e => new DoctorDTO
                {
                    IdDoctor = e.IdDoctor,
                    Email = e.Doctor.Email,
                    FirstName = e.Doctor.FirstName,
                    LastName = e.Doctor.LastName,
                }).FirstOrDefault();

            PatientDTO patient = _context.Prescriptions
                .Where(e => e.IdPrescription == IdPrescription)
                .Include(e => e.Patient)
                .Select(e => new PatientDTO
                {
                    IdPatient = e.IdPatient,
                    Birthdate = e.Patient.Birthdate,
                    FirstName = e.Patient.FirstName,
                    LastName = e.Patient.LastName,
                }).FirstOrDefault();

            List<MedicamentDTO> medicaments = _context.MedicamentPrescriptions
                .Where(e => e.IdPrescription == IdPrescription)
                .Select(e => new MedicamentDTO
                {
                    IdMedicament = e.IdMedicament,
                    Description = e.Medicament.Description,
                    Name = e.Medicament.Name,
                    Type = e.Medicament.Type,
                }).ToList();

            PrescriptionDTO prescription = _context.Prescriptions
                .Where(e => e.IdPrescription == IdPrescription)
                .Select(e => new PrescriptionDTO { 
                    IdPrescription = e.IdPrescription,
                    Date = e.Date,
                    DueDate = e.Date,
                    Doctor = doctor,
                    Patient = patient,
                    Medicaments = medicaments
                })
                .FirstOrDefault();



            return new ResultDTO<PrescriptionDTO>
            {
                Result = prescription,
                Code = 200
            };

        }

        public async Task<ResultDTO<string>> InsertDoctorAsync(DoctorDTO doctor)
        {
            Doctor d = await _context.Doctors.Where(e => e.IdDoctor == doctor.IdDoctor).FirstOrDefaultAsync();

            if (d != null) {
                return new ResultDTO<string>
                {
                    Result = "Id is already exist!",
                    Code = 400
                };
            }

            await _context.AddAsync(new Doctor
            {
                //IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });

            await _context.SaveChangesAsync();

            return new ResultDTO<string>
            {
                Result = "Ok!",
                Code = 200
            };
        }

        public async Task<ResultDTO<string>> UpdateDoctorAsync(int IdDoctor, DoctorDTO doctor)
        {
            if (doctor.IdDoctor != IdDoctor) 
                return new ResultDTO<string>
                {
                    Result = "Not the same id!",
                    Code = 404
                };

            if (!await _context.Doctors.Where(e => e.IdDoctor == IdDoctor).AnyAsync())
                return new ResultDTO<string>
                {
                    Result = "Don't exist!",
                    Code = 404
                };

            Doctor d = await _context.Doctors.Where(e => e.IdDoctor == IdDoctor).FirstOrDefaultAsync();

            d.FirstName = doctor.FirstName;
            d.LastName = doctor.LastName;
            d.Email = doctor.Email;

            _context.Doctors.Update(d);

            await _context.SaveChangesAsync();

            return new ResultDTO<string>
            {
                Result = "Ok!",
                Code = 200
            };

        }
    }
}
