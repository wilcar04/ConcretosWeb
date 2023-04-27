using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concretos.Models
{
    public class Reactive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "El nombre debe tener al menos 6 caracteres.")]
        public string Name { get; set; }

    }
}