using BmiCalcWeb.ConceptModels;
using BmiCalcWeb.Models;
using BmiCalcWeb.Services;

namespace BmiCalcWeb.Data;

public interface IBmiRepository
{
    Person GetBmi(Person person, MeasurementSystem measurement);
}

public class BmiRepository : IBmiRepository
{
    private readonly ICalculationFactory _calculationFactory;
    private readonly IInterpretationService _interpretationService;

    public BmiRepository(ICalculationFactory calculationFactory, IInterpretationService interpretationService)
    {
        _calculationFactory = calculationFactory ?? throw new ArgumentNullException(nameof(calculationFactory));
        _interpretationService = interpretationService ?? throw new ArgumentNullException(nameof(interpretationService));
    }

    public Person GetBmi(Person person, MeasurementSystem measurementSystem)
    {
        var calculationService = _calculationFactory.Create(measurementSystem);
        person.Bmi = calculationService?.CalculateBmi(person);
        if (person.Bmi != null) person.BmiInterpretation = _interpretationService.InterpretBmi(person.Bmi.Value);

        return person;
    }
}
