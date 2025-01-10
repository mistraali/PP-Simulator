namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }

    public override bool Exist(Point p)
    {
        if (new Rectangle(new Point(0, 0), new Point(SizeX - 1, SizeY - 1)).Contains(p))
            return true;
        else
            return false;
    }

    public override Point Next(Point p, Direction d)
    {
        if (!Exist(p)) return p;
        Point np = p.Next(d);
        return new Point((np.X+20) % SizeX, (np.Y+20) % SizeY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (!Exist(p)) return p;
        Point np = p.NextDiagonal(d);
        return new Point((np.X + 20) % SizeX, (np.Y + 20) % SizeY);
    }
}
