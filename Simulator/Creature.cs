namespace Simulator;

public abstract class Creature
{
    //fields
    private string _name = "Unknown";
    private int _level = 1;

    //properties
    public string Name { 
        get => _name; 
        init
        {
            int minLength = 3;
            int maxLength = 25;
            _name = value;
            //trimming
            _name = _name.Trim();
            //cutting long names
            if (_name.Length > maxLength)
            {
                _name = _name.Substring(0, maxLength);
                _name = _name.Trim();
            }
            //filling short names
            if (_name.Length < minLength)
            {
                do
                {
                    _name += '#';
                } while (_name.Length < minLength);
            }
            //names should start with upper case
            _name = char.ToUpper(_name[0]) + _name.Substring(1);
        } 
    }
    public int Level 
    { 
        get => _level; 
        init
        {
            //fitting into brackets
            _level = value;
            _level = _level < 1 ? 1 : _level;
            _level = _level > 10 ? 10 : _level;
        } 
    }
    public abstract int Power { get; }

    public string Info => $"{Name} [{Level}]";

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
}
