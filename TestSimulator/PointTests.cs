using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldBeCreated()
    {
        int x = 5;
        int y = 10;
        var point = new Point(x, y);
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Fact]
    public void ToString_ShouldBeValidOutput()
    {
        int x = 5;
        int y = 10;
        var point = new Point(x, y);
        Assert.Equal("(5, 10)", point.ToString());
    }

    [Theory]
    [InlineData(5, 10, Direction.Right, 6, 10)]
    [InlineData(5, 10, Direction.Left, 4, 10)]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(5, 10, Direction.Down, 5, 9)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        Assert.Equal(new Point(expectedX, expectedY), point.Next(d));
    }

    [Theory]
    [InlineData(5, 10, Direction.Right, 6, 9)]
    [InlineData(5, 10, Direction.Left, 4, 11)]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(5, 10, Direction.Down, 4, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction d, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        Assert.Equal(new Point(expectedX, expectedY), point.NextDiagonal(d));
    }
}
