using BmiCalcWeb.ConceptModels;
using System.ComponentModel.DataAnnotations;

namespace BmiCalcWeb.Models
{
    public enum MeasurementSystem
    {
        Metric, US
    }
    public class WebPageModel
    {
        [Required]
        public Person person { get; set; }
        [Required]
        public MeasurementSystem measurementSystem { get; set; }

        public WebPageModel()
        {
            person = new Person();
        }

    }
}
