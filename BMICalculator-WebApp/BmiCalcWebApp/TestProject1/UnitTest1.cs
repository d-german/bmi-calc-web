namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}

[TestFixture]
public class BMIInterpreterTest
{
    [TestCase(18.0, "Under Weight")]
    //other test cases
    public void BMIInterpreterTests(double value, string expectedResult)
    {
        var interpreter = new BmiCalcWeb.Services.InterpretationService();
        var actualResult = interpreter.InterpretBmi(value);
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
