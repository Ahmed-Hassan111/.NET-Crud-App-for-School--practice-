using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEFApp.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        public string? StudentName { get; set; }
        public int StudentAge { get; set; }

        [Range(5, 18)]
        public bool IsActive { get; set;}
        public string? ImgName { get; set; }
    }
}
