using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using ClinicService.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClinicServiceTests
{
    /// <summary>
    /// ДОМАШНЯЯ РАБОТА: разработать методы тестирования контроллера PetController:
    /// Обновление данных UpdateTest
    /// Получение данных по всем животным GetAllTest
    /// Получение данных по конкретному животному GetByIdTest
    /// </summary>
    public class PetControllerTests
    {

        private PetController _petController;
        private PetRepository _petRepository;

        public PetControllerTests()
        {
            _petRepository = new PetRepository();
            _petController = new PetController(_petRepository);
        }

        [Fact]
        public void PetUpdateTest()
        {
            // [1] Подготовка данных для тестирования
            UpdatePetRequest updatePetRequest = new UpdatePetRequest();
            updatePetRequest.PetId = 1;
            updatePetRequest.ClientId = 1;
            updatePetRequest.Name = "Rex";
            updatePetRequest.Kind = "Dog";
            updatePetRequest.Age = 5;
            
            // [2] Исполнение тестируемого метода
            ActionResult<int> operationResult = _petController.Update(updatePetRequest);

            // [3] Подготовка эталонного результата (expected), проверка результата.
            int expectedOperationValue = 1;

            Assert.IsType<OkObjectResult>(operationResult.Result);
            //Assert.Equal<int>(expectedOperationValue, operationResult.Value);
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);
        }

        [Fact]
        public void PetUpdateBadRequestTest()
        {
            // [1] Подготовка данных для тестирования
            UpdatePetRequest updatePetRequest = new UpdatePetRequest();
            updatePetRequest.PetId = 1;
            updatePetRequest.ClientId = 1;
            updatePetRequest.Name = "R";
            updatePetRequest.Kind = "Dog";
            updatePetRequest.Age = 50;

            // [2] Исполнение тестируемого метода
            ActionResult<int> operationResult = _petController.Update(updatePetRequest);

            // [3] Подготовка эталонного результата (expected), проверка результата.
            int expectedOperationValue = 0;

            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            //Assert.Equal<int>(expectedOperationValue, operationResult.Value);
            Assert.Equal<int>(expectedOperationValue, (int)((BadRequestObjectResult)operationResult.Result).Value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100)]
        public void PetGetByIdTest(int petId)
        {
            // [2] Исполнение тестируемого метода
            ActionResult<Pet> operationResult = _petController.GetById(petId);

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<Pet>(((OkObjectResult)operationResult.Result).Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-50)]
        public void PetGetByIdBadRequestTest(int petId)
        {
            // [2] Исполнение тестируемого метода
            ActionResult<Pet> operationResult = _petController.GetById(petId);

            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<Pet>(((OkObjectResult)operationResult.Result).Value);
        }

        [Fact]
        public void GetAllPetsTest()
        {          
            ActionResult<List<Pet>> operationResult = _petController.GetAll();

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<List<Pet>>(((OkObjectResult)operationResult.Result).Value);
        }



        [Fact]
        public void PetCreateTest()
        {
            // [1] Подготовка данных для тестирования
            CreatePetRequest createPetRequest = new CreatePetRequest();
            createPetRequest.Name = "Барсик";
            createPetRequest.Age = 15;
            createPetRequest.ClientId = 1;

            // [2] Исполнение тестируемого метода
            ActionResult<int> operationResult = _petController.Create(createPetRequest);

            // [3] Подготовка эталонного результата (expected), проверка результата.
            int expectedOperationValue = 1;

            Assert.IsType<OkObjectResult>(operationResult.Result);
            //Assert.Equal<int>(expectedOperationValue, operationResult.Value);
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);


        }

        [Fact]
        public void PetCreateBadRequestTest()
        {
            // [1] Подготовка данных для тестирования
            CreatePetRequest createPetRequest = new CreatePetRequest();
            createPetRequest.Name = "Б";
            createPetRequest.Age = 55;
            createPetRequest.ClientId = 1;

            // [2] Исполнение тестируемого метода
            ActionResult<int> operationResult = _petController.Create(createPetRequest);

            // [3] Подготовка эталонного результата (expected), проверка результата.
            int expectedOperationValue = 0;

            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            //Assert.Equal<int>(expectedOperationValue, operationResult.Value);
            Assert.Equal<int>(expectedOperationValue, (int)((BadRequestObjectResult)operationResult.Result).Value);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100)]
        public void DeletePetTest(int petId)
        {
            // [2] Исполнение тестируемого метода
            ActionResult<int> operationResult = _petController.Delete(petId);

            // [3] Подготовка expected результата
            int expectedOperationValue = 1;

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-50)]
        public void DeletePetBadRequestTest(int petId)
        {
            // [2] Исполнение тестируемого метода
            ActionResult<int> operationResult = _petController.Delete(petId);

            // [3] Подготовка expected результата
            int expectedOperationValue = 0;

            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((BadRequestObjectResult)operationResult.Result).Value);

        }
    }
}