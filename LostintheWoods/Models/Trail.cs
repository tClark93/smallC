using System.ComponentModel.DataAnnotations;
namespace LostintheWoods.Models
{
    public abstract class BaseEntity {}
    public class User : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(10)]
        [MaxLength(1000)]
        public string Description { get; set; }
 
        [Required]
        [Range(0.0, 100.0, ErrorMessage = "Please enter a number in km (0.0).")]
        public float Length { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Please enter an integer in m.")]
        public float Elevation { get; set; }
 
        [Required]
        [Range(-45.0, 45.0, ErrorMessage = "Please enter valid coordinate.")]
        public float Long { get; set; }

        [Required]
        [Range(-45.0, 45.0, ErrorMessage = "Please enter valid coordinate.")]
        public float Lat { get; set; }
    }
}