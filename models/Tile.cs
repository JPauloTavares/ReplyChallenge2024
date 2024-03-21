public class TileType
{
    public TileType(string ID, int cost,  int avaliable)
    {
        this.ID = ID;
        this.cost = cost;
        this.avaliable = avaliable;
        permittedMovementsList =  permittedMovements[ID];
    }
    
    public string ID { get; private set; }
    public int avaliable { get; set; }
    public int cost { get; set; }
    List<Directions> permittedMovementsList { get; set; }

    enum Directions
    {
      Up,
      Down,
      Left,
      Right  
    }

    Dictionary<String, List<Directions>> permittedMovements = new Dictionary<String, List<Directions>>()
    {
        {"3", new List<Directions> {Directions.Right, Directions.Left}},   // Tile 3: Move right
        {"5", new List<Directions> {Directions.Down,  Directions.Right}},   // Tile 5: Move down and right
        {"6", new List<Directions> { Directions.Down,  Directions.Left}},   // Tile 6: Move left and down
        {"7", new List<Directions> { Directions.Right,  Directions.Left, Directions.Down}},    // Tile 7: Move right, down, and right
        {"9", new List<Directions> { Directions.Up, Directions.Right}},  // Tile 9: Move up and right
        {"A", new List<Directions> { Directions.Left, Directions.Up}},  // Tile A: Move up
        {"B", new List<Directions> { Directions.Right,  Directions .Left,  Directions.Up}}, // Tile B: Move right, up, and right
        {"C", new List<Directions> { Directions.Up,  Directions.Down}},  // Tile C: Move up and down
        {"D", new List<Directions> { Directions.Up,  Directions.Down,  Directions.Right}}, // Tile D: Move up, down, and right
        {"E", new List<Directions> { Directions.Left,  Directions .Up,  Directions.Down}}, // Tile E: Move left, up, and down
        {"F", new List<Directions> { Directions.Right,  Directions .Left,  Directions .Up,  Directions.Down}} // Tile F: Move right, left, up, down, and right
    };

}
