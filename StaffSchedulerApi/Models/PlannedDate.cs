namespace StaffSchedulerApi.Models
{
    public class PlannedDate
    {
        public int id { get; set; }

        public DateTime DateTimeStart { get; set; }
        public DateTime? EndTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

