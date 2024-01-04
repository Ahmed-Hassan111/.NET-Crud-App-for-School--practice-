using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoEFApp.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        public string? CourseName { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set;}


        [Range(0, 25)]
        public int CourseCapacity { get; set; }

    }
}
