namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }

    public override bool Exist(Point p)
    {
        if (new Rectangle(new Point(0,0), new Point(SizeX-1,SizeY-1)).Contains(p)) 
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
