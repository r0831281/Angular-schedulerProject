namespace StaffSchedulerApi.Models
{
    public class RequestedDate
    {
        public int Id { get; set; }

        public DateTime DateTimeStart { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public string description { get; set; }

    }
}
