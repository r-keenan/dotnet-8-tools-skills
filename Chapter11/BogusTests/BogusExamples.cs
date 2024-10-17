using Bogus;
using BusinessLogic;
using NSubstitute;
using Xunit.Abstractions;

namespace BogusTests;

public class BogusExamples
{
    private readonly ITestOutputHelper _output;
    private readonly Faker<User> _userFaker;

    public BogusExamples(ITestOutputHelper output)
    {
        _output = output;

        _userFaker = new Faker<User>()
            // config an incrementing index for the Id property
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            // Config the FirstName prop to be a random first name
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            // Config LastName with random
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            // Config Email with random
            .RuleFor(u => u.Email, f => f.Internet.Email())
            // Config the DOB prop to be random DOB up to 30 years earlier than 18 years ago
            .RuleFor(
                u => u.DateOfBirth,
                f => f.Date.Past(yearsToGoBack: 30, refDate: DateTime.Now.AddYears(-18))
            );
    }

    [Fact]
    public void IsAdult_ShouldReturnTrue_WhenUserIs18OrOlder()
    {
        // arrange
        IEmailSender emailSender = Substitute.For<IEmailSender>();
        UserService userService = new(emailSender);
        User user = _userFaker.Generate();

        _output.WriteLine($"{user}");

        // Act
        bool result = userService.IsAdult(user);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAdult_ShouldReturnFalse_WhenUserIsUnder18()
    {
        // Arrange
        IEmailSender emailSender = Substitute.For<IEmailSender>();
        UserService userService = new(emailSender);

        User user = _userFaker
            .Clone()
            // override the dob random
            .RuleFor(
                u => u.DateOfBirth,
                f => f.Date.Past(yearsToGoBack: 10, refDate: DateTime.Now.AddYears(-8))
            )
            .Generate();

        _output.WriteLine($"{user}");

        // Act
        bool result = userService.IsAdult(user);

        // Assert
        Assert.False(result);
    }
}
