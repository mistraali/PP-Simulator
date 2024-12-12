namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min) return min;
        else if (value > max) return max;
        else return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        if (value == null) return "###";
        value = value.Trim();
        if (value == null) return "###";

        if (value.Length > max)
        {
            value = value.Substring(0, max);
            value = value.Trim();
        }
        if (value.Length < min)
        {
            value = value.PadRight(min, placeholder);
        }

        return char.ToUpper(value[0]) + value.Substring(1); ;
    }
}