using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Hello, World!");
        SmallTorusMap map = new(6,8);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description="Króliki"}, new Birds() { Description="Orły", CanFly=true}, new Birds { Description="Strusie", CanFly=false}];
        List<Point> points = [new(2, 2), new(3, 1), new(1,0), new(4,6), new(4,2)];
        string moves = "dlrludlddurldul";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        int turnCount = 0;
        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            turnCount++;
            Console.WriteLine($"Turn {turnCount}:");
            Console.WriteLine($"{simulation.CurrentCreature.Name} goes {simulation.CurrentMoveName}:");
            simulation.Turn();
            mapVisualizer.Draw();
        }
        Console.WriteLine("End of simulation!");
    }
}
