namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        List<Direction> result = new();
        foreach (char c in input.ToUpper())
        {
            if (c == 'U') result.Add(Direction.Up);
            if (c == 'R') result.Add(Direction.Right);
            if (c == 'D') result.Add(Direction.Down);
            if (c == 'L') result.Add(Direction.Left);
        }
        return result;
    }
}
