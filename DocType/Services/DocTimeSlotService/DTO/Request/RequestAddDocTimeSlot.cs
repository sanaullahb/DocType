using DocType.Enums;

namespace DocType.Services.DocTimeSlotService.DTO.Request
{
    public class RequestAddDocTimeSlot
    {
        public string DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public SlotType Type { get; set; }
    }
}
