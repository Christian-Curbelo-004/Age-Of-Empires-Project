using System;
using System.Text;

namespace ClassLibrary1.CivilizationDirectory
{
    public class PrintMap
    {
        private Map _map;

        public PrintMap(Map map)
        {
            _map = map;
        }

        public string GetMapAsString()
        {
            if (_map?.map == null)
            {
                return "The map is empty.";
            }

            int height = _map.map.GetLength(1);
            int length = _map.map.GetLength(0);
            
            int coordWidth = Math.Max(height, length).ToString().Length;
            string numFormat = new string('0', coordWidth);

            var result = new StringBuilder();
            
            result.Append(' ', coordWidth + 1);
            for (int j = 0; j < length; j++)
            {
                result.Append(j.ToString(numFormat) + " ");
            }
            result.AppendLine();

            for (int i = 0; i < height; i++)
            {
                result.Append(i.ToString(numFormat) + " ");
                for (int j = 0; j < length; j++)
                {
                    Cell cell = _map.map[j, i];
                    result.Append($"{cell.ToString().PadRight(coordWidth)} ");
                }
                result.AppendLine(i.ToString(numFormat));
            }
            result.Append(' ', coordWidth + 1);
            for (int j = 0; j < length; j++)
            {
                result.Append(j.ToString(numFormat) + " ");
            }
            result.AppendLine();

            return result.ToString();
        }
    }
}