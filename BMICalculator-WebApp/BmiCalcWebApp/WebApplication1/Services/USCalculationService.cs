using BmiCalcWeb.ConceptModels;

namespace BmiCalcWeb.Services
{
    public class USCalculationService : ICalculationService
    {
        public double CalculateBmi(Person person)
        {
            return 703 * ((double)person.Weight / (person.Height * person.Height));
        }
    }
}
