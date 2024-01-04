using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoEFApp.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  RoomId { get; set; }

        [MaxLength(10)]
        [MinLength(5)]
        public string? RoomName { get; set; }
        
    }
}
