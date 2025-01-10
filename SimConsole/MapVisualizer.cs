using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class MapVisualizer
{

    public Map Map { get; }
    public char[,] Drawing {  get; set; }
    
    public MapVisualizer(Map map)
    {
        this.Map = map;
        this.Drawing = new char[map.SizeX*2 + 1, map.SizeY*2 + 1];
        DrawBoundries();
        Draw();
    }

    public void Draw()
    {
        //Updating map with new positions
        for (int j = 0; j < (Drawing.GetLength(1) - 1) / 2; j++)
            for (int i = 0; i < (Drawing.GetLength(0) - 1) / 2; i++)
                if (Map.MapCreatures[i, j] != null)
                {
                    if (Map.MapCreatures[i, j].Count == 0) Drawing[i * 2 + 1, j * 2 + 1] = ' ';
                    else if (Map.MapCreatures[i, j].Count > 1) Drawing[i * 2 + 1, j * 2 + 1] = 'X';
                    else Drawing[i * 2 + 1, j * 2 + 1] = Map.MapCreatures[i, j][0].Symbol;
                }

        //Drawing map
        for (int j = Drawing.GetLength(1) - 1; j >= 0 ; j--)
        {
            for (int i = 0; i < Drawing.GetLength(0); i++)
                Console.Write(Drawing[i, j]);
            Console.WriteLine();
        }
    }

    public void DrawBoundries()
    {
        int sizeX = Drawing.GetLength(0);
        int sizeY = Drawing.GetLength(1);

        Drawing[0, 0] = Box.BottomLeft;
        Drawing[sizeX - 1, 0] = Box.BottomRight;
        for (int i = 1; i < sizeX - 1; i++) Drawing[i, 0] = (i % 2 == 0) ? Box.BottomMid : Box.Horizontal;
        for (int j = 1; j < sizeY - 1; j++)
            if (j % 2 == 1) 
                for (int i = 0; i < sizeX; i++) Drawing[i, j] = (i % 2 == 0) ? Box.Vertical : ' ';
            else
            {
                Drawing[0, j] = Box.MidLeft;
                Drawing[sizeX - 1, j] = Box.MidRight;
                for (int i = 1; i < sizeX - 1; i++) Drawing[i, j] = (i % 2 == 0) ? Box.Cross : Box.Horizontal;
            }
                
        Drawing[0, sizeY - 1] = Box.TopLeft;
        Drawing[sizeX - 1, sizeY - 1] = Box.TopRight;
        for (int i = 1; i < sizeX - 1; i++) Drawing[i, sizeY - 1] = (i % 2 == 0) ? Box.TopMid : Box.Horizontal;
   
    }
}
