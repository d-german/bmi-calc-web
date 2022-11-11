namespace TestProject1;

[TestFixture]
public class BMIInterpreterTest
{
    [TestCase(18.0, "Under Weight")]
    //other test cases
    public void BMIInterpreterTests(double value, string expectedResult)
    {
        var interpreter = new BmiCalcWeb.Services.InterpretationService();
        var actualResult = interpreter.InterpretBmiAsync(value);
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}