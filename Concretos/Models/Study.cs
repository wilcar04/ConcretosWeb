using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Concretos.Models
{
    public class Study
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "El campo fecha es obligatorio.")]
        [BindProperty]
        public DateTime CreatedDateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public Study()
        {
            this.CreatedDateTime = DateTime.Now;
        }

    }
}
