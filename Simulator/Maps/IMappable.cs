namespace Simulator.Maps;

public interface IMappable
{
    public Map? Map { get; set; }
    public Point? Position { get; set; }

    public string Name { get; }

    public char Symbol { get; }

    void Go(Direction d);
}
