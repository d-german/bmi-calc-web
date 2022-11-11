using BmiCalcWeb.ConceptModels;
using BmiCalcWeb.Models;

namespace BmiCalcWeb.Data;

public interface IBmiRepository
{
    Task<Person> GetBmiAsync(Person person, MeasurementSystem measurement);
}
