using BmiCalcWeb.ConceptModels;

namespace BmiCalcWeb.Services
{
    public class USCalculationService : ICalculationService
    {
        public Task<double> CalculateBmiAsync(Person person)
        {
            return Task.FromResult(703 * ((double)person.Weight / (person.Height * person.Height))); //blocking call
        }
    }
}
