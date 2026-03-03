namespace DocType.Services.DocScheduleService.DTO.Request
{
    public class RequestAddDoctorSchedule
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
