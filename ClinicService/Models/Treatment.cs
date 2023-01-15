namespace ClinicService.Models
{
    public class Treatment
    {

        public int TreatmentId { get; set; }

        public int ConsultationId { get; set; }

        public int DoctorId { get; set; }

        public string Prescription { get; set; }

        public int Price { get; set; }
    }
}
