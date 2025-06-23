using System;

namespace ClassLibrary1
{
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

        public string GetColoredRepresentation(out ConsoleColor color)
        {
            if (Resource != null)
            {
                switch (Resource.CollectionType)
                {
                    case "Gold":
                        color = ConsoleColor.Yellow;
                        return "GM";
                    case "Stone":
                        color = ConsoleColor.Gray;
                        return "SM";
                    case "Madera":
                        color = ConsoleColor.Green;
                        return "F";
                    default:
                        color = ConsoleColor.White;
                        return "?";
                }
            }

            if (Entity != null)
            {
                int ownerId = 0;
                string symbol = "?";

                if (Entity is Villagers v)
                {
                    ownerId = v.OwnerId;
                    symbol = "V";
                }
                else if (Entity is BuildingsDirectory.CivicCenter cc)
                {
                    ownerId = cc.OwnerId;
                    symbol = "CC";
                }
                else
                {
                    symbol = "?";
                }

                color = ownerId switch
                {
                    1 => ConsoleColor.Blue,
                    2 => ConsoleColor.Red,
                    _ => ConsoleColor.White
                };

                return symbol;
            }

            color = ConsoleColor.White;

            return EntityType switch
            {
                "Archer" => "A",
                "Paladin" => "P",
                "Raider" => "R",
                "Soldier" => "S",
                "Villagers" => "V",
                "ArcherCenter" => "AC",
                "ChivarlyCenter" => "ChC",
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
}