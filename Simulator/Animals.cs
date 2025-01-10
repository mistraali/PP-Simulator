using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";
    private uint size = 3;

    public required string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get => size; set => size = value; }
    public virtual string Info => $"{Description} <{Size}>";

    public Map? Map { get; set; }
    public Point? Position { get; set; }

    public string Name => Description;

    public virtual char Symbol => 'A';

    public virtual void Go(Direction direction)
    {
        if (Position != null && Map != null)
        {
            Point nextPosition = Map.Next((Point)Position, direction);
            Map.Move((Point)Position, nextPosition, this);
            Position = nextPosition;
        }
    }

    public override string ToString()
    {
        return GetType().Name.ToUpper() + ": " + Info;
    }

}
