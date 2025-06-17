using System;
using System.Text;

namespace ClassLibrary1
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

            var result = new StringBuilder();
            
            result.Append("     ");
            for (int j = 0; j < length; j++)
            {
                result.Append($"{j % 10} ");
            }
            result.AppendLine();

            for (int i = 0; i < height; i++)
            {
                result.Append($" {i % 10}  "); 
                for (int j = 0; j < length; j++)
                {
                    Cell cell = _map.map[j, i];
                    result.Append($"{cell} "); 
                }
                result.AppendLine($" {i % 10}"); 
            }
            
            result.Append("     "); 
            for (int j = 0; j < length; j++)
            {
                result.Append($"{j % 10} ");
            }
            result.AppendLine();

            return result.ToString();
        }
    }
}