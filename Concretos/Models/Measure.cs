using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concretos.Models
{
    public class Measure
    {

        public int Id { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public float ExperimentalPorosity { get; set; }

        public float ExpectedDensity { get; set; }

        public float ExpectedResistence { get; set; }
        
        public int FabricationMethodId { get; set; }

        [ForeignKey("FabricationMethodId")]
        public virtual FabricationMethod FabricationMethod { get; set; }

        public int ReactiveId { get; set; }

        [ForeignKey("ReactiveId")]
        public virtual Reactive Reactive { get; set; }

        #region Experimental measure

        public DateOnly ExperimentalDate { get; set; }

        public float ExperimentalDensity { get; set; }

        public float ExperimentalResistence { get; set; }

        public float DifferencePercentage { get; set; }

        #endregion

    }
}
