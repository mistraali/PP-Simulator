using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(2,1,5,2)]
    [InlineData(0,1,5,1)]
    [InlineData(6,1,5,5)]
    public void Limiter_ShouldSetProperValue(int limit, int min, int max, int expectation)
    {
        Assert.Equal(expectation, Validator.Limiter(limit, min, max));
    }

    [Theory]
    [InlineData("abcd","Abcd")]
    [InlineData("Ab","Ab#")]
    [InlineData("Abcdef","Abcde")]
    [InlineData("","###")]
    [InlineData("Ab ", "Ab#")]
    [InlineData("        Ab c  ", "Ab c")]
    public void Shortener_ShouldSetProperName(string input, string output)
    {
        Assert.Equal(output, Validator.Shortener(input, 3, 5, '#'));
    }
}
