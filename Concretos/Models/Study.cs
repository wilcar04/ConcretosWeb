using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Concretos.Models
{
    public class Study
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
