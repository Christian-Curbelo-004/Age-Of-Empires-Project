namespace ClassLibrary1;

public class Cell
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public bool IsOccupied { get; set; }
    public string ActionLetter { get; set; }

    public Cell(int x, int y)
    {
        PosX = x;
        PosY = y;
        IsOccupied = false;
        ActionLetter = "■"; 
    }

    public override string ToString()
    {
        return ActionLetter; 
    }
}