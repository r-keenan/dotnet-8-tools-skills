using FluentAssertions;
using FluentAssertions.Extensions;

namespace FluentTests;

public class FluentExamples
{
    [Fact]
    public void TestString()
    {
        string city = "London";
        string expectedCity = "London";

        city.Should().StartWith("Lo").And.EndWith("on").And.Contain("do").And.HaveLength(6);

        city.Should()
            .NotBeNull()
            .And.Be("London")
            .And.BeSameAs(expectedCity)
            .And.BeOfType<string>();

        city.Length.Should().Be(6);
    }

    [Fact]
    public void TestCollections()
    {
        string[] names = { "Alice", "Bob", "Charlie", "Dave" };

        names.Should().HaveCountLessThan(5, "because the max items should be 4 or fewer");

        names.Should().OnlyContain(name => name.Length <= 7);
    }

    [Fact]
    public void TestDateTimes()
    {
        DateTime when = new(hour: 9, minute: 30, second: 0, day: 25, month: 3, year: 2024);

        when.Should().Be(25.March(2024).At(9, 30));

        when.Should().BeOnOrAfter(23.March(2024));

        when.Should().NotBeSameDateAs(12.February(2024));

        when.Should().HaveYear(2024);

        DateTime due = new(hour: 13, minute: 0, second: 0, day: 25, month: 3, year: 2024);

        when.Should().BeAtLeast(2.Hours()).Before(due);
    }
}
