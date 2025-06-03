using System;
using System.Collections.Generic;
namespace ClassLibrary1;

public class Map
{
    private bool[,] map;
    public int MinDimension = 0;
    public int MaxDimension = 10;

    public int height
    {
        get;
        private set;
    }
    

    public int width
    {
        get;
        private set;
    }
    public Map(int height, int width, bool [,] map = null)
    {
        this.height = Math.Max(MinDimension, Math.Min(MaxDimension, height));
        this.width = Math.Max(MinDimension, Math.Min(MaxDimension, width));
        this.map = new bool[width, height];
        if (map != null )
        {
            for (int i = 0; i < Math.Min(width, map.GetLength(dimension: 0)); i++)
            {
                for (int x = 0; x < Math.Min(height, map.GetLength(dimension: 1)); x++)
                {
                    this.map[i, x] = map[i, x];
                }
            }
        }
    }
}
