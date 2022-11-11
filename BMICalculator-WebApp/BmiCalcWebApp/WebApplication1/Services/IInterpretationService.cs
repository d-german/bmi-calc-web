namespace BmiCalcWeb.Services
{
    public interface IInterpretationService
    {
        public Task<string> InterpretBmiAsync(double bmi);
    }
}
