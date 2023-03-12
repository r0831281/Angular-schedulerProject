using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffSchedulerApi.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
       
    }
}
