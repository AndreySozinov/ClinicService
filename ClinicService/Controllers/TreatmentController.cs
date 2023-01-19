using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private ITreatmentRepository _treatmentRepository;

        public TreatmentController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }


        [HttpPost("create")]
        [SwaggerOperation(OperationId = "TreatmentCreate")]
        public ActionResult<int> Create([FromBody] CreateTreatmentRequest createRequest)
        {
            int res = _treatmentRepository.Create(new Treatment
            {
                ConsultationId = createRequest.ConsultationId,
                DoctorId = createRequest.DoctorId,
                Prescription = createRequest.Prescription,
                Price = createRequest.Price
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "TreatmentUpdate")]
        public ActionResult<int> Update([FromBody] UpdateTreatmentRequest updateRequest)
        {
            int res = _treatmentRepository.Update(new Treatment
            {
                TreatmentId = updateRequest.TreatmentId,
                ConsultationId = updateRequest.ConsultationId,
                DoctorId = updateRequest.DoctorId,
                Prescription = updateRequest.Prescription,
                Price = updateRequest.Price
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "TreatmentDelete")]
        public ActionResult<int> Delete(int treatmentId)
        {
            int res = _treatmentRepository.Delete(treatmentId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "TreatmentGetAll")]
        public ActionResult<List<Treatment>> GetAll()
        {
            return Ok(_treatmentRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "TreatmentGetById")]
        public ActionResult<Treatment> GetById(int treatmentId)
        {
            return Ok(_treatmentRepository.GetById(treatmentId));
        }
    }
}
