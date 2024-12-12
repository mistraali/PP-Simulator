﻿namespace Simulator;

public class Elf : Creature
{
    //fields
    private int _agility = 1;
    private int _singCounter = 0;

    //properties
    public int Agility
    {
        get => _agility;
        init
        {
            if (_agility < 0) _agility = 0;
            else if (_agility > 10) _agility = 10;
            else _agility = value;
        }
    }

    public override int Power
    {
        get => 8 * Level + 2 * Agility;
    }

    //constructors
    public Elf() : base("Unknown elf", 1) { }
    public Elf(string name, int level = 1, int agility = 0) : base(name, level) { Agility = agility; }

    //methods
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    
    public void Sing()
    {
        _singCounter++;
        if (_singCounter == 3)
        {
            _singCounter = 0;
            if (Agility < 10) _agility++;
        }
        Console.WriteLine($"{Name} is singing.");
    }
}