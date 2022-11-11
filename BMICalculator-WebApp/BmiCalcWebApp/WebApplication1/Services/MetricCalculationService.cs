using BmiCalcWeb.ConceptModels;

namespace BmiCalcWeb.Services
{
    public class MetricCalculationService : ICalculationService
    {
        public Task<double> CalculateBmiAsync(Person person)
        {
            return Task.Run(() => (double )person.Weight / (person.Height * person.Height));
        }
    }
}
