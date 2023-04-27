using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concretos.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria.")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El campo de nombres es obligatorio.")]
        public string Names { get; set; }

        [Required(ErrorMessage = "El campo de apellidos es obligatorio.")]
        public string LastNames { get; set; }

    }
}
