namespace TestProject1;

[TestFixture]
public class BMIInterpreterTest
{
    [TestCase(18.0, "Under Weight")]
    //other test cases
    public async Task BMIInterpreterTests(double value, string expectedResult)
    {
        var interpreter = new BmiCalcWeb.Services.InterpretationService();
        var actualResult = await interpreter.InterpretBmiAsync(value);
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
