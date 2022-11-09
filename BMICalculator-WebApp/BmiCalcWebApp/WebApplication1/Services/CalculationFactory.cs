using BmiCalcWeb.Models;

namespace BmiCalcWeb.Services;

public class CalculationFactory : ICalculationFactory
{
    public ICalculationService? Create(MeasurementSystem measurementSystem)
    {
        return measurementSystem switch
        {
            MeasurementSystem.Metric => new MetricCalculationService(),
            MeasurementSystem.US => new USCalculationService(),
            _ => null
        };
    }
}
