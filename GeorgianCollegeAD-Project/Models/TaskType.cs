using System.ComponentModel.DataAnnotations;

namespace GeorgianCollegeAD_Project.Models
{
    public class TaskType
    {
        public int TaskTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Type Name")]
        public string? TaskTypeName { get; set; }

        [Display(Name = "Description")]
        public string? TaskTypeDescription { get; set; }

        public List<Task>? Tasks { get; set; }
    }
}
