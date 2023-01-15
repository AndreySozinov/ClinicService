namespace ClinicService.Models.Requests
{
    public class UpdateTreatmentRequest
    {
        public int TreatmentId { get; set; }

        public int ConsultationId { get; set; }

        public int DoctorId { get; set; }

        public string Prescription { get; set; }

        public int Price { get; set; }
    }
}
