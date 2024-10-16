using BusinessLogic;
using Xunit.Abstractions;

namespace BusinessLogicUnitTests;

public class CalculatorUnitTests: IDisposable 
{
    private readonly Calculator _sut;
    private readonly ITestOutputHelper _output;

    public CalculatorUnitTests(ITestOutputHelper output)
    {
        _sut = new();
        _output = output;

        _output.WriteLine("Constructor runs before each test.");
    }

    [Fact]
    public void TestAdding2And2()
    {
        _output.WriteLine($"Running {nameof(TestAdding2And2)}");
        // Arrange
        double number1 = 2;
        double number2 = 2;
        double expected = 4;

        Calculator sut = new();

        // Act
        double actual = sut.Add(number1, number2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAdding2And3() 
    {
        _output.WriteLine($"Running {nameof(TestAdding2And3)}");
        // Arrange
        double number1 = 2;
        double number2 = 3;
        double expected = 5;

        Calculator sut = new();

        // Act
        double actual = sut.Add(number1, number2);

        // Assert
        Assert.Equal(expected, actual);
    }

    // InlineData example
    [Theory]
    [InlineData(4, 2, 2)]
    [InlineData(5, 2, 3)]
    public void TestAdding(double expected, double number1, double number2) 
    {
        _output.WriteLine($"Running {nameof(TestAdding)}");
        // Arrange
        Calculator sut = new();

        // Act
        double actual = sut.Add(number1, number2);

        // Assert
        Assert.Equal(expected, actual);
    }

    // ClassData example
    [Theory]
    [ClassData(typeof(AddingNumbersData))]
    public void TestAddingPartTwo(double expected, double number1, double number2) 
    {
        _output.WriteLine($"Running {nameof(TestAddingPartTwo)}");
        // Arrange
        Calculator sut = new();

        // Act
        double actual = sut.Add(number1, number2);

        // Assert
        Assert.Equal(expected, actual);
    }

    // strongly typed ClassData example
    [Theory]
    [ClassData(typeof(AddingNumbersDataTyped))]
    public void TestAddingPartThree(double expected, double number1, double number2) 
    {
        _output.WriteLine($"Running {nameof(TestAddingPartTwo)}");
        // Arrange
        Calculator sut = new();

        // Act
        double actual = sut.Add(number1, number2);

        // Assert
        Assert.Equal(expected, actual);
    }

    // testing theory methods using MethodData example
    [Theory]
    [MemberData(memberName: nameof(GetTestData))]
    public void TestAddingPartFour(double expected, double number1, double number2) 
    {
        _output.WriteLine($"Running {nameof(TestAddingPartTwo)}");
        // Arrange
        Calculator sut = new();

        // Act
        double actual = sut.Add(number1, number2);

        // Assert
        Assert.Equal(expected, actual);
    }

    // Testing theory methods using MethodData
    public static IEnumerable<object[]> GetTestData()
    {
        // Test adding 2 and 2 to get 4
        yield return new object[] {4, 2, 2};

        // Test adding 2 and 3 to get 5
        yield return new object[] {5, 2, 3};
    }

    public void Dispose()
    {
        // Cleanup the _sut if necessary
        _output.WriteLine("Dispose runs afters each test.");
    }
}