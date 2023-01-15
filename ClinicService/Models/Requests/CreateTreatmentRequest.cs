namespace ClinicService.Models.Requests
{
    public class CreateTreatmentRequest
    {
        public int ConsultationId { get; set; }

        public int DoctorId { get; set; }

        public string Prescription { get; set; }

        public int Price { get; set; }
    }
}
