using System.Numerics;

namespace DocType.Models
{
    public class DocAvailability : Base<string>
    {
      

        public string DoctorId { get; set; }
        public Doc Doc { get; set; }

        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public int SlotDurationMinutes { get; set; } = 30;

        public bool IsActive { get; set; } = true;
    }
}
