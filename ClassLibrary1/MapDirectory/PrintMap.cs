using System.Text;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.QuaryDirectory;
using ClassLibrary1.UnitsDirectory;

namespace ClassLibrary1.MapDirectory
{
    public class PrintMap
    {
        private readonly Map _map;

        public PrintMap(Map map)
        {
            _map = map;
        }
        public string DisplayMap()
        {
            if (_map?.Cells == null)
            {
                return "El mapa está vacío.";
            }

            int height = _map.Cells.GetLength(1);
            int length = _map.Cells.GetLength(0);

            int coordWidth = Math.Max(height, length).ToString().Length;
            string numFormat = new string('0', coordWidth);
            int cellWidth = 4;

            var sb = new StringBuilder();
            sb.Append(' ', coordWidth + 1);
            for (int x = 0; x < length; x++)
                sb.Append(x.ToString(numFormat).PadRight(cellWidth));
            sb.AppendLine();

            // Filas
            for (int y = 0; y < height; y++)
            {
                sb.Append(y.ToString(numFormat).PadRight(coordWidth) + " ");
                for (int x = 0; x < length; x++)
                {
                    var cell = _map.Cells[x, y];
                    var (symbol, color) = GetSymbolAndColor(cell);
                    sb.Append(symbol.PadRight(cellWidth));
                }
                sb.AppendLine(y.ToString(numFormat).PadRight(coordWidth));
            }

            sb.Append(' ', coordWidth + 1);
            for (int x = 0; x < length; x++)
                sb.Append(x.ToString(numFormat).PadRight(cellWidth));
            sb.AppendLine();

            return sb.ToString();
        }

        public void StartDisplay(int refreshRateMs = 500)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(DisplayMap());
                Thread.Sleep(refreshRateMs);
            }
        }

        private (string symbol, ConsoleColor color) GetSymbolAndColor(Cell cell)
        {
            if (cell.Entity is IMapEntity entity)
            {
                string symbol = GetSymbolForEntity(entity);

                ConsoleColor color = entity switch
                {
                    GoldMine => ConsoleColor.Yellow,
                    StoneMine => ConsoleColor.DarkCyan,
                    Forest => ConsoleColor.Green,
                    _ => entity.OwnerId switch
                    {
                        1 => ConsoleColor.Blue,
                        2 => ConsoleColor.Red,
                        _ => ConsoleColor.Gray
                    }
                };

                return (symbol, color);
            }

            if (cell.Resource is IResource resource)
            {
                return resource switch
                {
                    GoldMine => ("G", ConsoleColor.Yellow),
                    StoneMine => ("S", ConsoleColor.DarkCyan),
                    Forest => ("F", ConsoleColor.Green),
                    _ => ("R", ConsoleColor.Gray)
                };
            }
            return ("[]", ConsoleColor.DarkGray);
        }

        private string GetSymbolForEntity(IMapEntity entity)
        {
            return entity switch
            {
                Villagers => "V",
                CivicCenter => "C",
                GoldMine => "G",
                Forest => "F",
                StoneMine => "S",
                _ => "?"
            };
        }
    }
}
