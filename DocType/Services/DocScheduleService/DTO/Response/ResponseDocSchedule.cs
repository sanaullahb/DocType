namespace DocType.Services.DocScheduleService.DTO.Response
{
    public class ResponseDoctorSchedule
    {
        public string Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
