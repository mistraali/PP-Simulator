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
        for (int j = 0; j < (Drawing.GetLength(0) - 1)/2; j++)
            for (int i = 0; i < (Drawing.GetLength(1) - 1) / 2; i++)
                if (Map.MapCreatures[i, j] != null) {
                    if (Map.MapCreatures[i, j].Count == 0) Drawing[j * 2 + 1, i * 2 + 1] = ' ';
                    else if (Map.MapCreatures[i, j].Count > 1) Drawing[j*2+1, i*2+1] = 'X';
                    else if (Map.MapCreatures[i, j][0].GetType() == typeof(Orc)) Drawing[j * 2 + 1, i * 2 + 1] = 'O';
                    else Drawing[j * 2 + 1, i * 2 + 1] = 'E';
                }

        //Drawing map
        for (int i = Drawing.GetLength(0) - 1; i >= 0 ; i--)
        {
            for (int j = 0; j < Drawing.GetLength(1); j++)
                Console.Write(Drawing[i, j]);
            Console.WriteLine();
        }
    }

    public void DrawBoundries()
    {
        int sizeX = Drawing.GetLength(0);
        int sizeY = Drawing.GetLength(1);

        Drawing[0, 0] = Box.BottomLeft;
        Drawing[0, sizeY - 1] = Box.BottomRight;
        for (int j = 1; j < sizeY -1 ; j++) Drawing[0, j] = (j % 2 == 0) ? Box.BottomMid : Box.Horizontal;
        for (int i = 1; i < sizeX - 1; i++)
            if (i % 2 == 1) 
                for (int j = 0; j < sizeY; j++) Drawing[i, j] = (j % 2 == 0) ? Box.Vertical : ' ';
            else
            {
                Drawing[i, 0] = Box.MidLeft;
                Drawing[i, sizeY -1] = Box.MidRight;
                for (int j = 1; j < sizeY - 1; j++) Drawing[i, j] = (j % 2 == 0) ? Box.Cross : Box.Horizontal;
            }
                
        Drawing[sizeX - 1, 0] = Box.TopLeft;
        Drawing[sizeX - 1, sizeY - 1] = Box.TopRight;
        for (int j = 1; j < sizeY - 1; j++) Drawing[sizeX - 1, j] = (j % 2 == 0) ? Box.TopMid : Box.Horizontal;
   
    }
}
