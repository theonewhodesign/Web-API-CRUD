using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    [Table("Employee")]
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Firstname { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Lastname { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string City { get; set; }
    }
}

