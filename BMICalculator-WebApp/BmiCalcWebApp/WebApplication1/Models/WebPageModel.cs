using BmiCalcWeb.ConceptModels;
using System.ComponentModel.DataAnnotations;

namespace BmiCalcWeb.Models
{
    public record WebPageModel
    {
        [Required]
        public Person Person { get; init; } = new ();
        [Required]
        public MeasurementSystem MeasurementSystem { get; init; }
    }
}
