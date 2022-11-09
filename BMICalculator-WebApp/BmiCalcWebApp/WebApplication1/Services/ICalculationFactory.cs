using BmiCalcWeb.Models;

namespace BmiCalcWeb.Services;

public interface ICalculationFactory
{
    public ICalculationService? Create(MeasurementSystem measurementSystem);
}
