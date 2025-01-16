using Simulator;

/// <summary>
/// State of map after single simulation turn.
/// </summary>
public class SimulationTurnLog
{
    /// <summary>
    /// Text representastion of moving object in this turn.
    /// CurrentMappable.ToString()
    /// </summary>
    public required string Mappable { get; init; }
    /// <summary>
    /// Text representation of move in this turn.
    /// CurrentMoveName.ToString();
    /// </summary>
    public required string Move { get; init; }
    /// <summary>
    /// Dictionary of IMappable.Symbol on the map in this turn.
    /// </summary>
    public required Dictionary<Point, char> Symbols { get; init; }

    public string StrigifySymbols()
    {
        string result = string.Empty;
        foreach (var kvp in Symbols) result += $"{kvp.Key.X} {kvp.Key.Y} {kvp.Value} ";
        return result.Trim();
    }

    public static Dictionary<Point, char> DestrigifySymbols(string str)
    {
        Dictionary<Point, char> symbols = [];
        string[] keys = str.Split(' ');
        for (int i = 0; i < keys.Length; i += 3)
        {
            symbols[new Point(int.Parse(keys[i]) , int.Parse(keys[i+1]))] = char.Parse(keys[i+2]);
        }
        return symbols;
    }
}