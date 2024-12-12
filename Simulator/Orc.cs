namespace Simulator;

public class Orc : Creature
{
    //fields
    private int _rage = 1;
    private int _huntCounter = 0;

    //properties
    public int Rage
    {
        get => _rage;
        init
        {
            if (_rage < 0) _rage = 0;
            else if (_rage > 10) _rage = 10;
            else _rage = value;
        }
    }

    public override int Power
    {
        get => 7 * Level + 3 * Rage;
    }

    //constructors
    public Orc() : base("Unknown orc", 1) { }
    public Orc(string name, int level = 1, int rage = 0) : base(name, level) { Rage = rage; }

    //methods
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    

    public void Hunt()
    {
        _huntCounter++;
        if (_huntCounter == 2)
        {
            _huntCounter = 0;
            if (Rage < 10) _rage++;
        }
        Console.WriteLine($"{Name} is hunting.");
    }
}
