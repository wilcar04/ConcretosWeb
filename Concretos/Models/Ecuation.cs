using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concretos.Models
{
    public class Ecuation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FabricationMethodId { get; set; }

        [ForeignKey("FabricationMethodId")]
        public virtual FabricationMethod FabricationMethod { get; set; }

        public int ReactiveId { get; set; }

        [ForeignKey("FabricationMethodId")]
        public virtual Reactive Reactive { get; set; }

    }
}
