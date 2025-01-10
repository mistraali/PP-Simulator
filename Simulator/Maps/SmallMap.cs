namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20) throw new ArgumentOutOfRangeException("Map cannot be smaller than 5!");

        SizeX = sizeX;
        SizeY = sizeY;
    }

    public override bool Exist(Point p)
    {
        throw new NotImplementedException();
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
}
