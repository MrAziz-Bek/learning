namespace CalculatorApp.Test;

public class MathHelperTest
{
    [Fact]
    public void IsEvenTest()
    {
        var calculator = new MathFormulas();

        var x = 1;
        var y = 2;

        var xResult = calculator.IsEven(x);
        var yResult = calculator.IsEven(y);

        Assert.False(xResult);
        Assert.True(yResult);
    }

    [Theory]
    [InlineData(1, 2, 1)]
    [InlineData(1, 3, 2)]
    public void DiffTest(int x, int y, int expectedResult)
    {
        var calculator = new MathFormulas();
        var result = calculator.Diff(x, y);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 6)]
    [InlineData(new[] { -4, -6, -10 }, -20)]
    public void SumTest(int[] numbers, int expectedResult)
    {
        var calculator = new MathFormulas();
        var result = calculator.Sum(numbers);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(4, 6, 10)]
    public void AddTest(int x, int y, int expectedResult)
    {
        var calculator = new MathFormulas();
        var result = calculator.Add(x, y);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(new[] { 4, 6, 2, 4 }, 4)]
    [InlineData(new[] { -10, -1, -7, -10, -2 }, -6)]
    public void AverageTest(int[] numbers, int expectedResult)
    {
        var calculator = new MathFormulas();
        var result = calculator.Average(numbers);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(MathFormulas.Data), MemberType = typeof(MathFormulas))]
    public void Add_MemberData_Test(int x, int y, int expectedResult)
    {
        var calculator = new MathFormulas();
        var result = calculator.Add(x, y);
        Assert.Equal(expectedResult, result);
    }

    [Theory(Skip = "This is just a reason...")]
    [ClassData(typeof(MathFormulas))]
    public void Add_ClassData_Test(int x, int y, int expectedResult)
    {
        var calculator = new MathFormulas();
        var result = calculator.Add(x, y);
        Assert.Equal(expectedResult, result);
    }
}