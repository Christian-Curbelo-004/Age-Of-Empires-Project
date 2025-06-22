
using System;

namespace ClassLibrary1;

public class Cell
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public bool IsOccupied { get; set; }
    public string EntityType { get; set; }
    public int Speed { get; set; }
    public Quary Resource { get; set; }
    public IMapEntidad Entity { get; set; }

    public Cell(int x, int y, int speed = 1000)
    {
        PosX = x;
        PosY = y;
        IsOccupied = false;
        EntityType = null;
        Speed = speed;
        Resource = null;
        Entity = null;
    }

    public string GetColoredRepresentation()
    {
        if (Resource != null)
        {
            switch (Resource.CollectionType)
            {
                case "Gold":
                    Console.ForegroundColor = ConsoleColor.Yellow; // Color amarillo para GoldMine
                    return "GM";
                case "Stone":
                    Console.ForegroundColor = ConsoleColor.Gray; // Color gris para StoneMine
                    return "SM";
                case "Madera":
                    Console.ForegroundColor = ConsoleColor.Green; // Color verde para Forest
                    return "F";
                default:
                    Console.ResetColor(); // Restaurar color original
                    return "?";
            }
        }

        Console.ResetColor(); // Restaurar color original para otros casos
        return EntityType switch
        {
            "Archer" => "A",
            "Paladin" => "P",
            "Raider" => "R",
            "Soldier" => "S",
            "Villagers" => "V",
            "ArcherCenter" => "AC",
            "ChivalryCenter" => "ChC",
            "CivicCenter" => "CC",
            "Home" => "H",
            "InfanteryCenter" => "IC",
            "GoldDeposit" => "GD",
            "SonteDeposit" => "SD",
            "WindMill" => "WM",
            "WoodDeposit" => "WD",
            "Forest" => "F",
            "GoldMine" => "GM",
            "StoneMine" => "SM",
            _ => "■"
        };
    }
}
