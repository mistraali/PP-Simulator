namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public readonly int Size;

    public SmallSquareMap(int size)
    {
        if (5 <= size && size <= 20) Size = size;
        else throw new ArgumentOutOfRangeException("Pick size between 5 and 20!");
    }

    public override bool Exist(Point p)
    {
        if (new Rectangle(new Point(0,0), new Point(Size,Size)).Contains(p)) 
            return true;
        else 
            return false;
    }

    public override Point Next(Point p, Direction d)
    {
        Point np = p.Next(d);
        if (Exist(np)) 
            return np;
        else return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point np = p.NextDiagonal(d);
        if (Exist(np))
            return np;
        else return p;
    }
}
