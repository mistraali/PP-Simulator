using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(0,5,2,8)]
    [InlineData(0,8,2,5)]
    [InlineData(2,5,0,8)]
    [InlineData(2,8,0,5)]
    public void Constructor_ValidPointsFromInts_ShouldCreateValidPoints(int x1, int y1, int x2, int y2)
    {
        var r = new Rectangle(x1,y1,x2,y2);
        Assert.Equal([0, 5, 2, 8], [r.X1,r.Y1,r.X2,r.Y2]);
    }

    [Theory]
    [InlineData(0, 5, 2, 8)]
    [InlineData(0, 8, 2, 5)]
    [InlineData(2, 5, 0, 8)]
    [InlineData(2, 8, 0, 5)]
    public void Constructor_ValidPointsFromPoints_ShouldCreateValidPoints(int x1, int y1, int x2, int y2)
    {
        Point p1 = new Point(x1,y1);
        Point p2 = new Point(x2,y2);
        var r = new Rectangle(p1, p2);
        Assert.Equal([0, 5, 2, 8], [r.X1, r.Y1, r.X2, r.Y2]);
    }

    [Theory]
    [InlineData(0,5,0,8)]
    [InlineData(0,5,2,5)]
    public void Constructor_InvalidPointsFromInts_ShouldThrowException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1,y1,x2,y2));
    }

    [Theory]
    [InlineData(0, 5, 0, 8)]
    [InlineData(0, 5, 2, 5)]
    public void Constructor_InvalidPointsFromPoints_ShouldThrowException(int x1, int y1, int x2, int y2)
    {
        Point p1 = new Point(x1, y1);
        Point p2 = new Point(x2, y2);
        Assert.Throws<ArgumentException>(() => new Rectangle(p1, p2));
    }

    [Fact]
    public void ToString_ShouldBeValidOutput()
    {
        int x1 = 0;
        int y1 = 5;
        int x2 = 2;
        int y2 = 8;
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal("(0, 5):(2, 8)", rectangle.ToString());
    }

    [Fact]
    public void Contains_ValidPoint_ShouldReturnTrue()
    {
        var rectangle = new Rectangle(0, 5, 2, 8);
        Assert.True(rectangle.Contains(new Point(1,7)));
    }

    [Theory]
    [InlineData(-1,6)]
    [InlineData(1,4)]
    [InlineData(6,8)]
    [InlineData(2,9)]
    public void Contains_InvalidPoints_ShouldReturnFalse(int x, int y)
    {
        var rectangle = new Rectangle(0, 5, 2, 8);
        Assert.False(rectangle.Contains(new Point(x,y)));
    }
}
