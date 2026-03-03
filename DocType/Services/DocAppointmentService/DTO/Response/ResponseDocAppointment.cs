using DocType.Enums;

namespace DocType.Services.DocAppointmentService.DTO.Response
{
    public class ResponseAppointment
    {
        public string Id { get; set; }

        public string DoctorId { get; set; }
        public string PatientId { get; set; }

        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }

        public AppointmentType AppointmentType { get; set; }
        public AppointmentStatus Status { get; set; }

        public decimal DoctorFee { get; set; }
        public decimal PlatformFee { get; set; }
        public decimal TotalAmount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

     
    }
}
