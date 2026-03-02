namespace DocType.Enums
{
   
        public enum AppointmentType
        {
            Online = 1,
            HomeVisit = 2
        }

        public enum AppointmentStatus
        {
            Pending = 1,
            Accepted = 2,
            Rejected = 3,
            Completed = 4,
            Cancelled = 5
        }

        public enum PaymentStatus
        {
            Unpaid = 1,
            Paid = 2,
            Refunded = 3
        }
    public enum SlotType
    {
        ClinicVisit,
        OnlineConsultation,
        HomeVisit
    }
}
