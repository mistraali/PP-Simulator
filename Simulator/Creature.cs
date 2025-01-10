using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    //fields
    private string _name = "Unknown";
    private int _level = 1;

    //properties
    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }
    public int Level 
    { 
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }
    public abstract int Power { get; }

    public abstract string Info {  get; }

    public Point? Position { get; set; }

    public Map? Map { get; set; }

    public virtual char Symbol => 'C';

    //constructors
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    /// <summary>
    /// Forces creature to say hello.
    /// </summary>
    /// <returns></returns>
    public abstract string Greeting();

    /// <summary>
    /// Advance creature by 1 level.
    /// </summary>
    public void Upgrade()
    {
        if (Level < 10) _level++;
    }

    /// <summary>
    /// Moves creature in direction. Requires map and position to be present.
    /// </summary>
    /// <param name="direction">Give direction to move.</param>
    public void Go(Direction direction) {
        if (Position != null && Map != null)
        {
            Point nextPosition = Map.Next((Point)Position, direction);
            Map.Move((Point)Position, nextPosition, this);
            Position = nextPosition;
        }
    }
}
