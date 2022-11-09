using BmiCalcWeb.ConceptModels;
using System.ComponentModel.DataAnnotations;

namespace BmiCalcWeb.Models
{
    public class WebPageModel
    {
        [Required]
        public Person Person { get; set; }
        [Required]
        public MeasurementSystem MeasurementSystem { get; set; }

        public WebPageModel()
        {
            Person = new Person();
        }

    }
}
