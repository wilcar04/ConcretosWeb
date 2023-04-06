using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Concretos.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
