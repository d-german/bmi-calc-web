using BmiCalcWeb.ConceptModels;
using BmiCalcWeb.Models;

namespace BmiCalcWeb.Data;

public interface IBmiRepository
{
    Person GetBmi(Person person, MeasurementSystem measurement);
}
