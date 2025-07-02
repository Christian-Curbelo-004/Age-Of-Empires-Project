using System.Text;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
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

        // Devuelve el mapa como string plano, para enviar en chat (Discord)
        public string DisplayMap()
        {
            if (_map?.Cells == null)
                return "El mapa está vacío.";

            int height = _map.Cells.GetLength(1);
            int length = _map.Cells.GetLength(0);

            int coordWidth = Math.Max(height, length).ToString().Length;
            string numFormat = new string('0', coordWidth);
            int cellWidth = 4; // ancho fijo para cada celda

            var sb = new StringBuilder();

            // Encabezado superior con coordenadas X
            sb.Append(' ', coordWidth + 1);
            for (int x = 0; x < length; x++)
                sb.Append(x.ToString(numFormat).PadRight(cellWidth));
            sb.AppendLine();

            // Filas con coordenadas Y y símbolos
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

            // Encabezado inferior con coordenadas X
            sb.Append(' ', coordWidth + 1);
            for (int x = 0; x < length; x++)
                sb.Append(x.ToString(numFormat).PadRight(cellWidth));
            sb.AppendLine();

            return sb.ToString();
        }

        // Obtiene símbolo para la celda (sin color, solo texto)
        private string GetSymbolForCell(Cell cell)
        {
            if (cell.Entity is IMapEntity entity)
            {
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

            return "[]"; // celda vacía
        }

        // Símbolos para entidades
        private string GetSymbolForEntity(IMapEntity entity)
        {
            return entity switch
            {
                // Tropas
                Villagers => "Vi",
                Archer => "Ar",
                Infantery => "In",
                Paladin => "Pa",
                Raider => "Ra",
                Chivarly => "Ch",
                Centuries => "Ce",

                // Edificios
                CivicCenter => "Cc",
                Home => "Ho",
                InfanteryCenter => "In",
                ArcherCenter => "AC",
                PaladinCenter => "PC",
                RaiderCenter => "RC",
                ChivarlyCenter => "CH",
                CenturiesCenter => "CE",

                // Recursos (si alguna vez son entidad)
                GoldMine => "Gm",
                StoneMine => "Sm",
                Forest => "Fo",

                _ => "??"
            };
        }
    }
}
