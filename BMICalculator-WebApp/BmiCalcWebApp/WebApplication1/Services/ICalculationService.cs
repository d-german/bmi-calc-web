using BmiCalcWeb.ConceptModels;

namespace BmiCalcWeb.Services;

public interface ICalculationService
{
    public Task<double> CalculateBmiAsync(Person person);
}
