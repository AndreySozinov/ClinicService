using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateDoctorRequest createRequest)
        {
            int res = _doctorRepository.Create(new Doctor
            {
                Surname = createRequest.Surname,
                FirstName = createRequest.FirstName,
                Patronymic = createRequest.Patronymic,
                Birthday = createRequest.Birthday
            });
            return Ok(res);
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateDoctorRequest updateRequest)
        {
            int res = _doctorRepository.Update(new Doctor
            {
                DoctorId = updateRequest.DoctorId,
                Surname = updateRequest.Surname,
                FirstName = updateRequest.FirstName,
                Patronymic = updateRequest.Patronymic,
                Birthday = updateRequest.Birthday
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        public ActionResult<int> Delete(int doctorId)
        {
            int res = _doctorRepository.Delete(doctorId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public ActionResult<List<Doctor>> GetAll()
        {
            return Ok(_doctorRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Doctor> GetById(int doctorId)
        {
            return Ok(_doctorRepository.GetById(doctorId));
        }
    }
}
