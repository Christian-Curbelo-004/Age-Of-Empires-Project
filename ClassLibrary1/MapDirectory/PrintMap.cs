
using System;
using System.Threading;

namespace ClassLibrary1.CivilizationDirectory
{
    public class PrintMap
    {
        private Map _map;

        public PrintMap(Map map)
        {
            _map = map;
        }

        public void DisplayMap()
        {
            if (_map?.map == null)
            {
                Console.WriteLine("The map is empty.");
                return;
            }

            int height = _map.map.GetLength(1);
            int length = _map.map.GetLength(0);

            int coordWidth = Math.Max(height, length).ToString().Length;
            string numFormat = new string('0', coordWidth); 
            int cellWidth = 4; 
            
            Console.Write(new string(' ', coordWidth + 1));
            for (int j = 0; j < length; j++)
            {
                Console.Write(j.ToString(numFormat).PadRight(cellWidth)); 
            }
            Console.WriteLine();

            for (int i = 0; i < height; i++)
            {

                Console.Write(i.ToString(numFormat).PadRight(coordWidth) + " ");
                for (int j = 0; j < length; j++)
                {
                    Cell cell = _map.map[j, i];
                    Console.ForegroundColor = GetCellColor(cell);
                    
                    string cellRepresentation = cell.GetColoredRepresentation().PadRight(cellWidth); 
                    Console.Write(cellRepresentation);
                    Console.ResetColor();
                }
                Console.WriteLine(i.ToString(numFormat).PadRight(coordWidth));
            }
            
            Console.Write(new string(' ', coordWidth + 1));
            for (int j = 0; j < length; j++)
            {
                Console.Write(j.ToString(numFormat).PadRight(cellWidth)); 
            }
            Console.WriteLine();
        }
        private ConsoleColor GetCellColor(Cell cell)
        {
            if (cell.Resource != null)
            {
                return cell.Resource.CollectionType switch
                {
                    "Gold" => ConsoleColor.Yellow, 
                    "Stone" => ConsoleColor.Gray, 
                    "Madera" => ConsoleColor.Green, 
                    _ => ConsoleColor.White 
                };
            }
            return ConsoleColor.White; 
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
    }
}