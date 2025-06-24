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

        public void DisplayMap()
        {
            if (_map?.Cells == null)
            {
                Console.WriteLine("El mapa está vacío.");
                return;
            }

            int height = _map.Cells.GetLength(1);
            int length = _map.Cells.GetLength(0);

            int coordWidth = Math.Max(height, length).ToString().Length;
            string numFormat = new string('0', coordWidth);
            int cellWidth = 4;

            // Encabezado de columnas
            Console.Write(new string(' ', coordWidth + 1));
            for (int x = 0; x < length; x++)
                Console.Write(x.ToString(numFormat).PadRight(cellWidth));
            Console.WriteLine();

            // Filas
            for (int y = 0; y < height; y++)
            {
                Console.Write(y.ToString(numFormat).PadRight(coordWidth) + " ");
                for (int x = 0; x < length; x++)
                {
                    var cell = _map.Cells[x, y];
                    var (symbol, color) = GetSymbolAndColor(cell);

                    Console.ForegroundColor = color;
                    Console.Write(symbol.PadRight(cellWidth));
                    Console.ResetColor();
                }
                Console.WriteLine(y.ToString(numFormat).PadRight(coordWidth));
            }

            Console.Write(new string(' ', coordWidth + 1));
            for (int x = 0; x < length; x++)
                Console.Write(x.ToString(numFormat).PadRight(cellWidth));
            Console.WriteLine();
        }

        public void StartDisplay(int refreshRateMs = 500)
        {
            while (true)
            {
                Console.Clear();
                DisplayMap();
                Thread.Sleep(refreshRateMs);
            }
        }

        private (string symbol, ConsoleColor color) GetSymbolAndColor(Cell cell)
        {
            if (cell.Entity is IMapEntity entity)
            {
                string symbol = GetSymbolForEntity(entity);
                ConsoleColor color = entity.OwnerId switch
                {
                    1 => ConsoleColor.Blue,
                    2 => ConsoleColor.Red,
                    _ => ConsoleColor.Gray
                };
                return (symbol, color);
            }
            
            if (cell.Resource is IResource resource)
            {
                return resource switch
                {
                    GoldMine => ("G", ConsoleColor.Yellow),
                    StoneMine => ("S", ConsoleColor.DarkGray),
                    Forest => ("F", ConsoleColor.Green),
                    _ => ("R", ConsoleColor.Gray)
                };
            }

            // Celda vacía
            return ("·", ConsoleColor.DarkGray);
        }

        private string GetSymbolForEntity(IMapEntity entity)
        {
            return entity switch
            {
                Villagers => "V",
                CivicCenter => "C",
                _ => "?"
            };
        }
    }
}
