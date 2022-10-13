using System.ComponentModel.DataAnnotations;

namespace GeorgianCollegeAD_Project.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        [Required]
        public String? TaskName { get; set; }

        [Required]
        public int TaskTypeID { get; set; }

        public String? TaskDescription { get; set; }

        public String? TaskNotes { get; set; }

        public TaskType? TaskType { get; set; }

        public List<Employee_Task>? Employee_Tasks { get; set; }
    }
}
