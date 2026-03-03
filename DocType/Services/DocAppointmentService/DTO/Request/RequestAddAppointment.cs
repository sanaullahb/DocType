using DocType.Enums;

namespace DocType.Services.DocAppointmentService.DTO.Request
{
    public class RequestAddAppointment
    {
        public string DoctorId { get; set; }
        public string PatientId { get; set; }

        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }

        public AppointmentType AppointmentType { get; set; }

     
    }
    public class RequestUpdateAppointmentStatus
    {
        public AppointmentStatus Status { get; set; }
    }
}
