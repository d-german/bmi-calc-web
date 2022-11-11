using BmiCalcWeb.ConceptModels;
using BmiCalcWeb.Models;
using BmiCalcWeb.Services;

namespace BmiCalcWeb.Data;

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

        var personResponse = person with { Bmi = calculationService?.CalculateBmi(person) };

        if (personResponse.Bmi != null) personResponse = personResponse with { BmiInterpretation = _interpretationService.InterpretBmi(personResponse.Bmi.Value) };

        return personResponse;
    }
}
