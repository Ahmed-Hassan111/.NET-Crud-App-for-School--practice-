using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoEFApp.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        public string? TeacherName { get; set; }
        [Range(22, 70)]
        public int TeacherAge { get; set; }
    }
}
