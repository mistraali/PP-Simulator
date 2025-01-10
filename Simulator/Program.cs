namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }
    static void Lab5a()
    {
        var createRectangle = new Action<List<Object>>(points =>
        {
            try
            {
                if (points.Count == 2)
                    Console.WriteLine(new Rectangle((Point)points[0], (Point)points[1]));
                else if (points.Count == 4)
                    Console.WriteLine(new Rectangle((int)points[0], (int)points[1], (int)points[2], (int)points[3]));
                else
                    throw new ArgumentException();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid points!");
            }
        });

        int x1 = 0;
        int y1 = 5;
        int x2 = 2;
        int y2 = 8;
        List<Object> l0 = new List<Object> { x1, y1, x2, y2 };
        createRectangle(l0);    //(0, 5):(2, 8)

        Point p1 = new Point(0,5);
        Point p2 = new Point(2,8);
        List<Object> l1 = new List<Object> { p1, p2 };
        createRectangle(l1);    //(0, 5):(2, 8)

        Point p3 = new Point(0, 10);
        Point p4 = new Point(2, 8);
        List<Object> l2 = new List<Object> { p3, p4 };
        createRectangle(l2);    //(0, 8):(2, 10)

        Point p5 = new Point(0, 10);
        Point p6 = new Point(2, 10);
        List<Object> l3 = new List<Object> { p5, p6 };
        createRectangle(l3);    //Invalid points!

        Point p7 = new Point(2, 10);
        Point p8 = new Point(0, 8);
        List<Object> l4 = new List<Object> { p7, p8 };
        createRectangle(l4);    //(0, 8):(2, 10)
    }
}