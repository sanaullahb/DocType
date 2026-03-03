namespace DocType.Models
{
    public class Doc : Base<string>
    {
        public string? FullName { get; set; }   
        public string? Specialization { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }    
        public string? Country { get; set; }    
        public string? Gender { get; set; }
        public string? Cnic { get; set; }   
        public string? ConsultationFee { get; set; }
        public int? HomeVisitFees { get; set; } 
        public string? isAvailable { get; set; }
        public ICollection<DocAvailability>? Availabilities { get; set; }
        public ICollection<DocTimeSlot>? TimeSlots { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
