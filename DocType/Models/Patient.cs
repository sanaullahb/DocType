namespace DocType.Models
{
    public class Patient : Base<string>
    {          
            public string FullName { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }

            public ICollection<Appointment> Appointments { get; set; }
        }
    
}
