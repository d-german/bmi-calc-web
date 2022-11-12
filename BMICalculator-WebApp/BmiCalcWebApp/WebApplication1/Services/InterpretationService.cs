namespace BmiCalcWeb.Services
{
    public class InterpretationService : IInterpretationService
    {
        public Task<string> InterpretBmiAsync(double bmi)
        {
            return Task.Run(() => bmi switch
            {
                < 18.5 => "Under Weight",
                < 24.9 => "Normal",
                < 29.9 => "Overweight",
                > 29.9 => "Obese",
                _ => string.Empty
            });
        }
    }
}
