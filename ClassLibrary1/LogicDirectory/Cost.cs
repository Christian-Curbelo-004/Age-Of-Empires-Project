namespace ClassLibrary1.LogicDirectory;

public class Cost
{
    public int Food { get; set; }
    public int Wood { get; set; }
    public int Gold { get; set; }
    public int Stone { get; set; }

    public Cost(int food, int wood, int gold, int stone)
    {
        Food = food;
        Wood = wood;
        Gold = gold;
        Stone = stone;
    }
}