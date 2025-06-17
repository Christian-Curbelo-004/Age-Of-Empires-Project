namespace ClassLibrary1;

public class Cell
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public bool IsOccupied { get; set; }
    public string EntityType { get; set; } // Tipo de entidad en la celda

    public Cell(int x, int y)
    {
        PosX = x;
        PosY = y;
        IsOccupied = false;
        EntityType = null; // Por defecto, la celda está vacía
    }

    public override string ToString()
    {
        return EntityType switch
        {
            // Construcciones
            "ArcherCenter" => "AC",
            "ChivalryCenter" => "ChC",
            "CivicCenter" => "CC",
            "Home" => "H",
            "InfanteryCenter" => "IC",

            // Tropas
            "Archer" => "A",
            "Paladin" => "P",
            "Raider" => "R",
            "Soldier" => "S",
            "Villagers" => "V",

            // Depósitos
            "GoldDeposit" => "GD",
            "SonteDeposit" => "SD",
            "WindMill" => "WM",
            "WoodDeposit" => "WD",

            // Canteras
            "Forest" => "F",
            "GoldMine" => "GM",
            "StoneMine" => "SM",

            // Combates
            "AvA" => "AvA",
            "AvP" => "AvP",
            "AvR" => "AvR",
            "AvS" => "AvS",
            "AvV" => "AvV",
            "AvB" => "AvB",
            "PvP" => "PvP",
            "PvR" => "PvR",
            "PvS" => "PvS",
            "PvV" => "PvV",
            "PvB" => "PvB",
            "RvR" => "RvR",
            "RvS" => "RvS",
            "RvV" => "RvV",
            "RvB" => "RvB",
            "SvS" => "SvS",
            "SvV" => "SvV",
            "SvB" => "SvB",

            // Estados del aldeano
            "VfG" => "VfG",
            "VfS" => "VfS",
            "VfW" => "VfW",
            "VB" => "VB",
            "VFf" => "VFf",

            // Construcciones siendo atacadas
            "ACa" => "ACa",
            "ChCa" => "ChCa",
            "CCa" => "CCa",
            "Ha" => "Ha",
            "Ica" => "Ica",

            // Construcciones en construcción
            "BAC" => "BAC",
            "BChC" => "BChC",
            "BCC" => "BCC",
            "BH" => "BH",
            "BIC" => "BIC",

            // Producción de tropas
            "ACar" => "ACar",     // ArcherCenter fabricando arqueros
            "ChCc" => "ChCc",     // ChivalryCenter fabricando caballería
            "ICi" => "ICi",       // InfanteryCenter fabricando infantería

            // Depósitos llenos
            "GDf" => "GDf",
            "SDf" => "SDf",
            "WMf" => "WMf",
            "WDf" => "WDf",
            
            // Predeterminado para celdas vacías
            _ => "■"
        };
    }
}
