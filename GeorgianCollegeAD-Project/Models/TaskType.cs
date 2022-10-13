using System.ComponentModel.DataAnnotations;

namespace GeorgianCollegeAD_Project.Models
{
    public class TaskType
    {
        public int TaskTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? TaskTypeName { get; set; }

        public string? TaskTypeDescription { get; set; }

        public List<Task>? Tasks { get; set; }
    }
}
