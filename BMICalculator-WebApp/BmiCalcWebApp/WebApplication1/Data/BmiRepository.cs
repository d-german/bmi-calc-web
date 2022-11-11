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

    public async Task<Person> GetBmiAsync(Person person, MeasurementSystem measurementSystem)
    {
        var calculationService = _calculationFactory.Create(measurementSystem);

        var personResponse = person with { Bmi = await calculationService?.CalculateBmiAsync(person) };

        if (personResponse.Bmi != null) personResponse = personResponse with { BmiInterpretation = await _interpretationService.InterpretBmiAsync(personResponse.Bmi.Value) };

        return personResponse;
    }
}
