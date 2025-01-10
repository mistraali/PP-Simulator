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
    public abstract string Greeting();

    //advance by 1 level
    public void Upgrade()
    {
        if (Level < 10) _level++;
    }

    //move to single direction
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    //move to array of directions
    public String[] Go(Direction[] directions)
    {
        String[] strings = new String[directions.Length];
        int i = 0;
        foreach (Direction move in directions)
        {
            strings[i++] = new string(Go(move));
        }
        return strings;
    }

    //move to string of directions
    public String[] Go(string directions) => Go(DirectionParser.Parse(directions));

    public override string ToString()
    {
        return GetType().Name.ToUpper() + ": " + Info;
    }
}
