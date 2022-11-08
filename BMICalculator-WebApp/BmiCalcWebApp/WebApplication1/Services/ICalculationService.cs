using BmiCalcWeb.ConceptModels;

namespace BmiCalcWeb.Services
{
    public interface ICalculationService
    {
        public double CalculateBmi(Person person);

    }
}
