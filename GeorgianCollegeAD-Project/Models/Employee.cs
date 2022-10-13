using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GeorgianCollegeAD_Project.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string? Position { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Birthdate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public List<Employee_Task>? Employee_Tasks { get; set; }
    }
}
