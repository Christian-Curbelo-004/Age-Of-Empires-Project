using System;
using System.Collections.Generic;
namespace ClassLibrary1;

public class Map
{
    private int _height;
    private int _length;
    public Cell[,] map;
    
    private const int MinDimension = 0;
    private const int MaxDimension = 100;
    public Map(int height, int length)
    {
        _height= Math.Max(MinDimension, Math.Min(MaxDimension, height));
        _length= Math.Max(MinDimension, Math.Min(MaxDimension, length));
        this.map = new Cell[length, height];
        if (map != null )
        {
            for (int i = 0; i < Math.Min(length, map.GetLength(dimension: 0)); i++)
            {
                for (int x = 0; x < Math.Min(height, map.GetLength(dimension: 1)); x++)
                {
                    this.map[x,i] = new Cell(x,i);
                }
            }
        }
    }
}

public class ShowMap
{
    
}
