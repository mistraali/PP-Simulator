namespace Simulator;

internal class Rectangle
{
    public readonly int X1, Y1, X2, Y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
            throw new ArgumentException("Chosen points are collinear!");
        else
        {
            X1 = Math.Min(x1, x2);
            Y1 = Math.Min(y1, y2);
            X2 = Math.Max(x2, x1);
            Y2 = Math.Max(y2, y1);
        }
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";

    public bool Contains(Point point)
    {
        if (X1 <= point.X && point.X <= X2 && Y1 <= point.Y && point.Y <= Y2) return true;
        else return false;
    }
}
