using System.Numerics;

namespace DocType.Models
{
    public class DocTimeSlot : Base <string>
    {
    
  

            public string DoctorId { get; set; }
            public Doc Doc { get; set; }

            public DateOnly Date { get; set; }
            public TimeOnly Time { get; set; }

            public bool IsBooked { get; set; } = false;
        }
    
}
