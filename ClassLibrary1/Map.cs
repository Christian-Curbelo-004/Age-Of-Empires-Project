using System;
namespace ClassLibrary1
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map()
        {
            Width = 100;
            Height = 100;
        }
    }
}
