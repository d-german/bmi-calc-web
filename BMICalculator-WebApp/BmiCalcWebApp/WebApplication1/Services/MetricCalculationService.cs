using BmiCalcWeb.ConceptModels;

namespace BmiCalcWeb.Services
{
    public class MetricCalculationService : ICalculationService
    {
        public double CalculateBmi(Person person)
        {
            return person.Weight / (person.Height / 100.0 * (person.Height / 100.0));
        }
    }
}
