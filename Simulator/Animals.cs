namespace Simulator;

internal class Animals
{
    private string _description = "Unknown";
    private uint size = 3;

    public required string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get => size; set => size = value; }
    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString()
    {
        return GetType().Name.ToUpper() + ": " + Info;
    }

}
