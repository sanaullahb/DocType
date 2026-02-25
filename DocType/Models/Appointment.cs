using DocType.Enums;
using System.Numerics;

namespace DocType.Models
{
    public class Appointment :Base <string>
    {
   
     

            public string DoctorId { get; set; }
            public Doc Doctor { get; set; }

            public string PatientId { get; set; }
            public Patient Patient { get; set; }

            public DateOnly AppointmentDate { get; set; }
            public TimeOnly AppointmentTime { get; set; }

            public AppointmentType AppointmentType { get; set; }
            public AppointmentStatus Status { get; set; }

            public decimal DoctorFee { get; set; }
            public decimal PlatformFee { get; set; }
            public decimal TotalAmount { get; set; }

            public PaymentStatus PaymentStatus { get; set; }

            public string? HomeAddress { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }
    
}
