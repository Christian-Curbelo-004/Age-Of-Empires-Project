using System.Text;
using ClassLibrary1.QuaryDirectory;

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
                return "El mapa está vacío.";

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
            for (int y = 0; y < height; y++)
            {
                sb.Append(y.ToString(numFormat).PadRight(coordWidth) + " ");

                for (int x = 0; x < length; x++)
                {
                    var cell = _map.Cells[x, y];
                    string symbol = GetSymbolForCell(cell);
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

        public string DisplayMapSector(int startX, int endX, int startY, int endY)
        {
            if (_map?.Cells == null)
                return "El mapa está vacío.";

            int height = _map.Cells.GetLength(1);
            int width = _map.Cells.GetLength(0);

            startX = Math.Clamp(startX, 0, width);
            endX = Math.Clamp(endX, 0, width);
            startY = Math.Clamp(startY, 0, height);
            endY = Math.Clamp(endY, 0, height);

            const int coordWidth = 3;
            const int cellWidth = 3;

            var sb = new StringBuilder();

            // Encabezado columnas X
            sb.Append(' ', coordWidth);
            for (int x = startX; x < endX; x++)
                sb.Append(x.ToString("D2").PadLeft(cellWidth));
            sb.AppendLine();

            // Filas con coordenadas Y y celdas
            for (int y = startY; y < endY; y++)
            {
                sb.Append(y.ToString("D2").PadLeft(coordWidth - 1) + " ");

                for (int x = startX; x < endX; x++)
                {
                    string symbol = GetSymbolForCell(_map.Cells[x, y]);
                    sb.Append(symbol.PadRight(cellWidth));
                }

                sb.AppendLine();
            }

            // Pie con columnas X
            sb.Append(' ', coordWidth);
            for (int x = startX; x < endX; x++)
                sb.Append(x.ToString("D2").PadLeft(cellWidth));
            sb.AppendLine();

            return sb.ToString();
        }

        private string GetSymbolForCell(Cell cell)
        {
            if (cell.Entities.Count > 0)
            {
                var entity = cell.Entities[0];
                return GetSymbolForEntity(entity);
            }

            if (cell.Resource is IResource resource)
            {
                return resource switch
                {
                    GoldMine => "Gm",
                    StoneMine => "Sm",
                    Forest => "Fo",
                    _ => " R"
                };
            }

            return "."; 
        }

        private string GetSymbolForEntity(IMapEntity entity)
        {
            if (entity is Forest || entity is GoldMine || entity is StoneMine || entity is Farm)
            {
                return entity.Symbol ?? "??";
            }
            return $"{entity.Symbol}{entity.OwnerId}";
        }
    }
}