namespace ClinicService.Models
{
    public class Pet
    {
        public int PetId { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Kind { get; set; }

        public int Age { get; set; }
    }
}
