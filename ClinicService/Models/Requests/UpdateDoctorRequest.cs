namespace ClinicService.Models.Requests
{
    public class UpdateDoctorRequest
    {
        public int DoctorId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }
    }
}
