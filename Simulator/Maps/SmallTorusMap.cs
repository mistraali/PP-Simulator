namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;
    public SmallTorusMap(int size)
    {
        if (5 <= size && size <= 20) Size = size;
        else throw new ArgumentOutOfRangeException("Pick size between 5 and 20!");
    }
    public override bool Exist(Point p)
    {
        if (new Rectangle(new Point(0, 0), new Point(Size - 1, Size - 1)).Contains(p))
            return true;
        else
            return false;
    }

    public override Point Next(Point p, Direction d)
    {
        if (!Exist(p)) return p;
        Point np = p.Next(d);
        return new Point((np.X+20) % Size, (np.Y+20) % Size);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (!Exist(p)) return p;
        Point np = p.NextDiagonal(d);
        return new Point((np.X + 20) % Size, (np.Y + 20) % Size);
    }
}
