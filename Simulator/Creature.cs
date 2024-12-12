namespace Simulator;

public abstract class Creature
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

    //constructors
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    //methods
    //write greeting to console
    public abstract void SayHi();

    //advance by 1 level
    public void Upgrade()
    {
        if (Level < 10) _level++;
    }

    //move to single direction
    public void Go(Direction direction)
    {
        string lowerDirection = char.ToLower(direction.ToString()[0]) + direction.ToString().Substring(1);
        Console.WriteLine($"{Name} goes {lowerDirection}");
    }

    //move to array of directions
    public void Go(Direction[] directions)
    {
        foreach (Direction move in directions) Go(move);
    }

    //move to string of directions
    public void Go(string directions) => Go(DirectionParser.Parse(directions));

    public override string ToString()
    {
        return GetType().Name.ToUpper() + ": " + Info;
    }
}
