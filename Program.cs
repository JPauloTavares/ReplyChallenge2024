using System.Diagnostics.Contracts;
using System.Net;
using System.Text.Json.Serialization;

int goldenPointsQt = 0;
int silverPointsQt = 0;
int avaialbleTilesQt = 0;

    GridInfo gridInfo = new GridInfo
    {
        goldenPoints = new(),
        silverPoints = new()
    };


void PrintGrid(string[,] matrix){
    for (int i = 0; i < gridInfo.height; i++)
    {
        for (int j = 0; j < gridInfo.width; j++)
        {
            Console.Write(matrix[j, i] != null ? matrix[j, i] == "G" ? "[-G-]" :  $"[{matrix[j, i]}]" : "[---]");
        }
        Console.WriteLine();
    }
}

try
{
    StreamReader sr = new StreamReader("C:\\src\\reply\\Sample.txt");
    string[] dimensions = sr.ReadLine().Split(' ');
    gridInfo.width = int.Parse(dimensions[0]);
    gridInfo.height = int.Parse(dimensions[1]);
    gridInfo.avaialbleTiles = new List<TileType>();
    goldenPointsQt = int.Parse(dimensions[2]);
    silverPointsQt = int.Parse(dimensions[3]);
    avaialbleTilesQt = int.Parse(dimensions[4]);
    Console.WriteLine("WIDTH: " + gridInfo.width + "HEIGT: " + gridInfo.height + "GOLDEN POINTS: " + goldenPointsQt + "SILVER POINTS: " + silverPointsQt + "TILES: " + avaialbleTilesQt);

    string[,] matrix = new string[gridInfo.width + 1, gridInfo.height + 1];

    Console.WriteLine("GOLDEN POINTS: " + goldenPointsQt);
    for(int i = 0 ; i < goldenPointsQt; i++){
        //Console.WriteLine("GOLDEN LOOP: " + (goldenPointsQt - i));
        string[] coordinates = sr.ReadLine().Split(' ');
        Console.WriteLine(coordinates[0]);
        gridInfo.goldenPoints.Add(new GoldenPoint(int.Parse(coordinates[0]), int.Parse(coordinates[1])));
        matrix[int.Parse(coordinates[0]), int.Parse(coordinates[1])] = "G";
    }

    Console.WriteLine("SILVER POINTS: " + silverPointsQt);
    for(int i = 0 ; i < silverPointsQt; i++){
        //Console.WriteLine("SILVER LOOP: " + (silverPointsQt - i));
        string[] coordinates = sr.ReadLine().Split(' ');
        Console.WriteLine(coordinates[0]);
        gridInfo.silverPoints.Add(new SilverPoint(int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2])));
        matrix[int.Parse(coordinates[0]), int.Parse(coordinates[1])] = coordinates[2];
    }

    Console.WriteLine("TILES: " + avaialbleTilesQt);
    for(int i = 0 ; i < avaialbleTilesQt; i++){
        //Console.WriteLine("TILES LOOP: " + (avaialbleTilesQt - i));
        string[] info = sr.ReadLine().Split(' ');
        gridInfo.avaialbleTiles.Add(new TileType(info[0], int.Parse(info[1]), int.Parse(info[2])));
    }
    sr.Close();
    
    PrintGrid(matrix);

    //A PARTIR DAQ EH PATHFINDING

    Coordinate currentPoint = new Coordinate(gridInfo.width, gridInfo.height);
    foreach (GoldenPoint point in gridInfo.goldenPoints)
    {
        if (point.coordinates.X + point.coordinates.Y  < currentPoint.X + currentPoint.Y)
            currentPoint = point.coordinates; 
    }

    Coordinate temp = new Coordinate(gridInfo.width, gridInfo.height);
    (int, int) totalSteps = (0, 0);
    foreach(GoldenPoint point in gridInfo.goldenPoints)
    {
        int totalSum = (point.coordinates.X + point.coordinates.Y);
        if((totalSum - (currentPoint.X + currentPoint.Y)) < (temp.X + temp.Y))
            temp = point.coordinates; totalSteps = (temp.X - currentPoint.X, temp.Y - currentPoint.Y);
    }

    for(int i = currentPoint.Y ; i < temp.Y ; i ++){
        for(int j = currentPoint.X ; j < temp.X ; j ++){
            
        }
    }
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}





