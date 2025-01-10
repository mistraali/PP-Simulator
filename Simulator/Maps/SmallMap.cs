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

    public override void Add(Point p, Creature c)
    {
        if (this.Exist(p))
        {
            c.Map = this;
            c.Position = p;
            if (MapCreatures[p.X, p.Y] == null)
                MapCreatures[p.X, p.Y] = new List<Creature> { c };
            else
                MapCreatures[p.X, p.Y].Add(c);
        }
    }

    public override void Remove(Point p, Creature c)
    {
        if (this.Exist(p))
        {
            c.Map = null;
            c.Position = null;
            MapCreatures[p.X, p.Y].Remove(c);
        }
    }

    public override void Move(Point p1, Point p2, Creature c)
    {
        if (c.Map != null && this.Exist(p1) && this.Exist(p2))
        {
            c.Position = p2;
            MapCreatures[p1.X, p1.Y].Remove(c);
            if (MapCreatures[p2.X, p2.Y] == null)
                MapCreatures[p2.X, p2.Y] = new List<Creature> { c };
            else
                MapCreatures[p2.X, p2.Y].Add(c);
        }
    }

    public override List<Creature> At(Point p)
    {
        if (this.Exist(p))
            return MapCreatures[p.X, p.Y];
        else
            return null;
    }

    public override List<Creature> At(int x, int y)
    {
        if (this.Exist(new Point(x,y)))
            return MapCreatures[x, y];
        else
            return null;
    }

}
