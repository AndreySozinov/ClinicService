using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(OperationId = "DoctorCreate")]
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
        [SwaggerOperation(OperationId = "DoctorUpdate")]
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
        [SwaggerOperation(OperationId = "DoctorDelete")]
        public ActionResult<int> Delete(int doctorId)
        {
            int res = _doctorRepository.Delete(doctorId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "DoctorGetAll")]
        public ActionResult<List<Doctor>> GetAll()
        {
            return Ok(_doctorRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "DoctorGetById")]
        public ActionResult<Doctor> GetById(int doctorId)
        {
            return Ok(_doctorRepository.GetById(doctorId));
        }
    }
}
