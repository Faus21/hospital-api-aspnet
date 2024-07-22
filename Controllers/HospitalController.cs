using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task9.Entities;
using Task9.Models.DTO;
using Task9.Service;

namespace Task9.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    public class HospitalController : ControllerBase
    {

        private readonly IHospitalDbService _hospitalDbService;

        public HospitalController(IHospitalDbService hospitalDbService) { 
            _hospitalDbService = hospitalDbService;
        }


        [HttpGet("/doctors/{id}")]
        public IActionResult GetDoctorById(int id)
        {
            return Ok(_hospitalDbService.GetDoctor(id).Result);
        }


        [HttpGet("/prescription/{id}")]
        public IActionResult GetPrecById(int id)
        {
            return Ok(_hospitalDbService.GetPrescription(id).Result);
        }

        [HttpDelete("/doctors/{id}")]
        public async Task<IActionResult> DeleteDoctorById(int id)
        {
            ResultDTO<string> result =  await _hospitalDbService.DeleteDoctorAsync(id);
            if (result.Code == 404)
            {
                NotFound(result.Result);
            }

            return Ok(result.Result);
        }

        [HttpPut("/doctors/{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorDTO doctor)
        {
            ResultDTO<string> result = await _hospitalDbService.UpdateDoctorAsync(id, doctor);

            if (result.Code == 404)
            {
                NotFound(result.Result);
            } 

            return Ok(result.Result);
        }

        [HttpPost("/doctors")]
        public async Task<IActionResult> PostDoctor(DoctorDTO doctor)
        {
            ResultDTO<string> result = await _hospitalDbService.InsertDoctorAsync(doctor);

            if (result.Code == 400)
            {
                BadRequest(result.Result);
            }

            return Ok(result.Result);
        }


    }
}
