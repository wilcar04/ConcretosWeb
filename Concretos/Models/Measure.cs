using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concretos.Models
{
    public class Measure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Consecutive { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float ExperimentalPorosity { get; set; }
        
        public float ExpectedDensity { get; set; }

        public float ExpectedResistence { get; set; }

        [Required]
        public int FabricationMethodId { get; set; }

        [ForeignKey("FabricationMethodId")]
        public virtual FabricationMethod? FabricationMethod { get; set; }

        [Required]
        public int ReactiveId { get; set; }

        [ForeignKey("ReactiveId")]
        public virtual Reactive? Reactive { get; set; }

        [Required]
        public int StudyId { get; set; }

        [ForeignKey("StudyId")]
        public virtual Study? Study { get; set; }

        #region Experimental measure

        public DateTime ExperimentalDate { get; set; }

        public float ExperimentalDensity { get; set; }

        public float ExperimentalResistence { get; set; }

        public float DifferencePercentage { get; set; }

        #endregion

    }
}
