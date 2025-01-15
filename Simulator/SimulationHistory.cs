using Simulator;
using Simulator.Maps;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    //
    private void Run()
    {
        //Recording state before simulation begins
        var zeroTurn = new SimulationTurnLog()
        {
            Mappable = "No one",
            Move = "No moves yet",
            Symbols = new Dictionary<Point, char>()
        };
        for (int y = 0; y < SizeY; y++)
        {
            for (int x = 0; x < SizeX; x++)
            {
                if (_simulation.Map.At(x, y) != null)
                {
                    if (_simulation.Map.At(x, y).Count == 1)
                    {
                        zeroTurn.Symbols.Add(new Point(x, y), _simulation.Map.At(x, y)[0].Symbol);
                    }
                    else if (_simulation.Map.At(x, y).Count > 1)
                    {
                        zeroTurn.Symbols.Add(new Point(x, y), 'X');
                    }
                }
            }
        }
        TurnLogs.Add(zeroTurn);

        //Loop to record every turn
        while (!_simulation.Finished)
        {
            var newTurn = new SimulationTurnLog()
            {
                Mappable = _simulation.CurrentCreature.ToString(),
                Move = _simulation.CurrentMoveName.ToString(),
                Symbols = new Dictionary<Point, char>()
            };
            _simulation.Turn();
            for (int y = 0; y < SizeY; y++)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    if (_simulation.Map.At(x, y) != null)
                    {
                        if (_simulation.Map.At(x, y).Count == 1)
                        {
                            newTurn.Symbols.Add(new Point(x, y), _simulation.Map.At(x, y)[0].Symbol);
                        }
                        else if (_simulation.Map.At(x, y).Count > 1)
                        {
                            newTurn.Symbols.Add(new Point(x, y), 'X');
                        }
                    }
                }
            }
            TurnLogs.Add(newTurn);
        }
    }
}