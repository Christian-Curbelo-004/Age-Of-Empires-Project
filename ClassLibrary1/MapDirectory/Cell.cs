namespace ClassLibrary1;

public class Cell
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public bool IsOccupied { get; set; }
    public string EntityType { get; set; } // Tipo de entidad en la celda (ej. "Archer", "Paladin", "GoldDeposit", etc.)
    public IMapEntidad Entity { get; set; }

    public Cell(int x, int y)
    {
        PosX = x;
        PosY = y;
        IsOccupied = false;
        EntityType = null; 
    }

    public override string ToString()
    {
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

            // Canteras
            case "Forest": return "F";
            case "GoldMine": return "GM";
            case "StoneMine": return "SM";

            // Aldeano trabajando
            case "VfG": return "VfG"; // farmeando oro
            case "VfS": return "VfS"; // farmeando piedra
            case "VfW": return "VfW"; // farmeando madera
            case "VB": return "VB";   // construyendo
            case "VFf": return "VFf"; // lleno

            // Combates Archer
            case "AvA": return "AvA";
            case "AvP": return "AvP";
            case "AvR": return "AvR";
            case "AvS": return "AvS";
            case "AvV": return "AvV";
            case "AvB": return "AvB";

            // Combates Paladin
            case "PvP": return "PvP";
            case "PvR": return "PvR";
            case "PvS": return "PvS";
            case "PvV": return "PvV";
            case "PvB": return "PvB";

            // Combates Raider
            case "RvR": return "RvR";
            case "RvS": return "RvS";
            case "RvV": return "RvV";
            case "RvB": return "RvB";

            // Combates Soldier
            case "SvS": return "SvS";
            case "SvV": return "SvV";
            case "SvB": return "SvB";

            // Valor por defecto para celdas vacías u otras entidades desconocidas
            default: return "■";
        }
    }
}

