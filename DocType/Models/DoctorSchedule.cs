namespace DocType.Models
{
    public class DoctorSchedule : Base<string>
    {

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }   = DateTime.Now; 
        public string Description { get; set; } 
        public string Title { get; set; }
        public string Type { get; set; }    
        public string UserId { get; set; }  
        public string UserName { get; set; }    

    }
}
