using BusinessLogic;
using NSubstitute;
using Xunit.Abstractions;

namespace BusinessLogicUnitTests
{
    public class EmailSenderUnitTests
    {
        private readonly ITestOutputHelper _output;

        public EmailSenderUnitTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SendEmailTest()
        {
            // Arrange
            IEmailSender emailSender = Substitute.For<IEmailSender>();
            emailSender
                .SendEmail(
                    to: Arg.Any<string>(),
                    subject: Arg.Any<string>(),
                    body: Arg.Any<string>()
                )
                .Returns(true);

            emailSender
                .When(x =>
                    x.SendEmail(
                        to: Arg.Is<string>(s => s.EndsWith("example.com")),
                        subject: Arg.Any<string>(),
                        body: Arg.Any<string>()
                    )
                )
                .Do(x => _output.WriteLine("email sent to example domain."));

            UserService sut = new(emailSender);

            // Act
            bool result = sut.CreateUser("user@example.com", "password");

            // Assert
            Assert.True(result);
            emailSender
                .Received(requiredNumberOfCalls: 1)
                .SendEmail(
                    to: "user@example.com",
                    subject: Arg.Any<string>(),
                    body: Arg.Any<string>()
                );
        }
    }
}
