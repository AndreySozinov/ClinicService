using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public PetController()
        {
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "PetCreate")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createRequest)
        {
            if (createRequest.Age > 25 || createRequest.Name.Length < 3)
            {
                return BadRequest(0);
            }
            int res = _petRepository.Create(new Pet
            {
                ClientId = createRequest.ClientId,
                Name = createRequest.Name,
                Kind = createRequest.Kind,
                Age = createRequest.Age
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "PetUpdate")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updateRequest)
        {
            if (updateRequest.Age > 25 || updateRequest.Name.Length < 3)
            {
                return BadRequest(0);
            }
            int res = _petRepository.Update(new Pet
            {
                PetId = updateRequest.PetId,
                ClientId = updateRequest.ClientId,
                Name = updateRequest.Name,
                Kind = updateRequest.Kind,
                Age = updateRequest.Age
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "PetDelete")]
        public ActionResult<int> Delete(int petId)
        {
            if(petId <= 0)
            {
                return BadRequest(0);
            }
            int res = _petRepository.Delete(petId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "PetGetAll")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "PetGetById")]
        public ActionResult<Pet> GetById(int petId)
        {
            if(petId <= 0)
            {
                return BadRequest(null);
            }
            return Ok(_petRepository.GetById(petId));
        }
    }
}
