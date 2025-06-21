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

    public override string ToString()
    {
        if (Resource != null && Resource.CollectionValue > 0)
        {
            return $"{Resource.CollectionType}({Resource.CollectionValue})"; 
        }

        switch (EntityType)
        {
            // Tropas
            case "Archer": return "A";
            case "Paladin": return "P";
            case "Raider": return "R";
            case "Soldier": return "S";
            case "Villagers": return "V";

            // Construcciones
            case "ArcherCenter": return "AC";
            case "ChivalryCenter": return "ChC";
            case "CivicCenter": return "CC";
            case "Home": return "H";
            case "InfanteryCenter": return "IC";

            // Construcciones siendo atacadas
            case "ACa": return "ACa";
            case "ChCa": return "ChCa";
            case "CCa": return "CCa";
            case "Ha": return "Ha";
            case "Ica": return "Ica";

            // Construcciones en construcción
            case "BAC": return "BAC";
            case "BChC": return "BChC";
            case "BCC": return "BCC";
            case "BH": return "BH";
            case "BIC": return "BIC";

            // Producción de tropas
            case "ACar": return "ACar"; // ArcherCenter fabricando arqueros
            case "ChCc": return "ChCc"; // ChivalryCenter fabricando caballería
            case "ICi": return "ICi";   // InfanteryCenter fabricando infantería

            // Depósitos
            case "GoldDeposit": return "GD";
            case "SonteDeposit": return "SD";
            case "WindMill": return "WM";
            case "WoodDeposit": return "WD";

            // Depósitos llenos
            case "GDf": return "GDf";
            case "SDf": return "SDf";
            case "WMf": return "WMf";
            case "WDf": return "WDf";

            // Canteras con colores
            case "Forest":
                Console.ForegroundColor = ConsoleColor.Green; // Verde para Forest
                Console.Write("F");
                Console.ResetColor();
                return "";
            case "GoldMine":
                Console.ForegroundColor = ConsoleColor.Yellow; // Amarillo para GoldMine
                Console.Write("GM");
                Console.ResetColor();
                return "";
            case "StoneMine":
                Console.ForegroundColor = ConsoleColor.Gray; // Gris para StoneMine
                Console.Write("SM");
                Console.ResetColor();
                return "";

            default: return "■"; // Celda vacía o desconocida
        }
    }
}