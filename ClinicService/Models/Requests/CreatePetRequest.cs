namespace ClinicService.Models.Requests
{
    public class CreatePetRequest
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Kind { get; set; }

        public int Age { get; set; }
    }
}
