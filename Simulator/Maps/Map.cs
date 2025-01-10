using System.ComponentModel;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public List<Creature>[,] MapCreatures { get; set; }
    public int SizeX { get; init; }
    public int SizeY { get; init; }

    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5) throw new ArgumentOutOfRangeException("Map cannot be smaller than 5!");
    
        SizeX = sizeX;
        SizeY = sizeY;
        MapCreatures = new List<Creature>[SizeX,SizeY];
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public abstract bool Exist(Point p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    /// <summary>
    /// Adds creature to the map.
    /// </summary>
    /// <param name="p">Position of creature.</param>
    /// <param name="c">Creature to be added.</param>
    /// <returns></returns>
    public abstract void Add(Point p, Creature c);

    /// <summary>
    /// Removes creature from the map.
    /// </summary>
    /// <param name="p">Position of creature.</param>
    /// <param name="c">Creature to be removed.</param>
    public abstract void Remove(Point p, Creature c);

    /// <summary>
    /// Moves creature between points.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="c"></param>
    public abstract void Move(Point p1, Point p2, Creature c);

    /// <summary>
    /// Checks which creatures are at certain map point.
    /// </summary>
    /// <param name="p">Point to be checked.</param>
    public abstract List<Creature> At(Point p);

    /// <summary>
    /// Checks which creatures are at certain map point.
    /// </summary>
    /// <param name="x">X axis to be checked</param>
    /// <param name="y">Y axis to be checked</param>
    public abstract List<Creature> At(int x, int y);
}
