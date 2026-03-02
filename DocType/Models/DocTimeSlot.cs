using DocType.Enums;
using System.Numerics;

namespace DocType.Models
{
    public class DocTimeSlot : Base <string>
    {
    
  

            public string DoctorId { get; set; }
            public Doc Doc { get; set; }
            public DayOfWeek DayOfWeek => Date.DayOfWeek;
            public DateOnly Date { get; set; }
            public TimeOnly Time { get; set; }
            public SlotType Type { get; set; }

            public bool IsBooked { get; set; } = false;
        }
    
}
