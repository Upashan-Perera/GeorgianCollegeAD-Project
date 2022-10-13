using System.ComponentModel.DataAnnotations;

namespace GeorgianCollegeAD_Project.Models
{
    public class Employee_Task
    {
        [Required]
        public int Employee_TaskId { get; set; }
        [Required]
        public int TaskId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public Boolean IsCompleted { get; set; }

        [Required]
        public DateTime TimeDate { get; set; }

        public Employee? Employee { get; set; }

        public Task? Task { get; set; }
    }
}
