namespace ClassLibrary1.FacadeDirectory;

public static class GameConfig
{
    public record Position(int x, int y);
    public static readonly (int X, int Y) PlayerOneStart = (10, 10);
    public static readonly (int X, int Y) PlayerTwoStart = (90, 90);
    
    public static readonly (int x, int y) PlayerOneVillagerStart = (12, 12);
    public static readonly (int x, int y) PlayerTwoVillagerStart = (88, 88);

    public const int InitialWood = 100;
    public const int InitialFood = 100;
    public const int InitialGold = 0;
    public const int InitialStone = 0;

    public static readonly Position GoldMinePos = new (20, 20);
    public static readonly Position StoneMinePos = new (25, 25);
    public static readonly Position ForestPos = new (30, 30);
    public static readonly Position FarmPos = new (30, 30);
}
