using System.ComponentModel.DataAnnotations;

namespace BmiCalcWeb.ConceptModels
{
    public record Person
    {
        [Required]
        public int Height { get; init; }
        [Required]
        public int Weight { get; init; }

        public double? Bmi { get; init; }
        public string? BmiInterpretation { get; init; }
    }
}
