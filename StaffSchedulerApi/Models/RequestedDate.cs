using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffSchedulerApi.Models
{
    public class RequestedDate
    {
        public int Id { get; set; }

        public DateTime DateTimeStart { get; set; }
        public DateTime? EndTime { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Status { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

    }
}
