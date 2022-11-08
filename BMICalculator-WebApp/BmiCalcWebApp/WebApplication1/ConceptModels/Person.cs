using System.ComponentModel.DataAnnotations;

namespace BmiCalcWeb.ConceptModels
{
    public class Person
    {
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }

        public double? Bmi { get; set; }
        public string? BmiInterpretation { get; set; }
    }
}
