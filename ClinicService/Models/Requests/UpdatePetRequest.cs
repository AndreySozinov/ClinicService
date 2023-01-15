namespace ClinicService.Models.Requests
{
    public class UpdatePetRequest
    {
        public int PetId { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Kind { get; set; }

        public int Age { get; set; }
    }
}
