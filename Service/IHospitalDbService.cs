using Lecture8Examples.Models;
using Task9.Entities;
using Task9.Models.DTO;

namespace Task9.Service
{
    public interface IHospitalDbService
    {
        public ResultDTO<DoctorDTO> GetDoctor(int IdDoctor);

        public Task<ResultDTO<string>> DeleteDoctorAsync(int IdDoctor);
        
        public Task<ResultDTO<string>> UpdateDoctorAsync(int IdDoctor, DoctorDTO doctor);

        public Task<ResultDTO<string>> InsertDoctorAsync(DoctorDTO doctor);

        public ResultDTO<PrescriptionDTO> GetPrescription(int IdPrescription);

    }
}
