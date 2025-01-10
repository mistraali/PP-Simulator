using Simulator.Maps;
using Simulator;

public class Simulation
{
    private int _indexOfMoves = 0;


    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        get
        {
            return Creatures[_indexOfMoves % Creatures.Count];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            return DirectionParser.Parse(Moves)[_indexOfMoves].ToString().ToLower();
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        this.Map = map;
        if (creatures.Count == 0)
            throw new ArgumentException("Bad input for creatures!");
        else
            this.Creatures = creatures;
        if (positions.Count != creatures.Count)
            throw new ArgumentException("Bad input for creatures' positions!");
        else
            this.Positions = positions;
        for (int i = 0; i < positions.Count; i++)
        {
            map.Add(positions[i], creatures[i]);
        }
        this.Moves = moves;
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() {
        if (Finished) throw new InvalidOperationException("End of moves!");
        CurrentCreature.Go((Direction)Enum.Parse(typeof(Direction), char.ToUpper(CurrentMoveName[0]) + CurrentMoveName.Substring(1)));
        _indexOfMoves++;
        if (DirectionParser.Parse(Moves).Count == _indexOfMoves) Finished = true;
    }
}