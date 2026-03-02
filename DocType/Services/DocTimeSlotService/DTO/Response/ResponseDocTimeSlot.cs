namespace DocType.Services.DocTimeSlotService.DTO.Response
{
    public class ResponseDocTimeSlot
    {
        public string Id { get; set; }
        public string DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public bool IsBooked { get; set; }
    }
}
