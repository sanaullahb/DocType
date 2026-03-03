namespace DocType.Services.DocAvailaibilityService.DTO.Request
{
    public class RequestAddDocAvailability
    {

        public string DocId { get; set; }   
        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public int SlotDurationMinutes { get; set; } = 30;
    }
}
