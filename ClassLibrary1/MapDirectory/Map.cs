using System;

namespace ClassLibrary1.CivilizationDirectory;

public class Map
{
    private int _height;
    private int _length;
    public Cell[,] map; 
    
    
    public PlayerOne PlayerOne { get; set; }
    public PlayerTwo PlayerTwo { get; set; }

    
    private const int MinDimension = 0;
    private const int MaxDimension = 100;

    public Map(int height, int length)
    {
        _height = Math.Max(MinDimension, Math.Min(MaxDimension, height));
        _length = Math.Max(MinDimension, Math.Min(MaxDimension, length));
        this.map = new Cell[_length, _height];
        
        for (int i = 0; i < _length; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                this.map[i, j] = new Cell(i, j);
            }
        }
    }
    public bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < _length && y >= 0 && y < _height;
    }
    
    public bool IsCellOccupied(int x, int y)
    {
        if (IsWithinBounds(x, y))
        {
            return map[x, y].IsOccupied;
        }
        else
        {
            throw new ArgumentOutOfRangeException($"La posición ({x}, {y}) está fuera de los límites del mapa.");
        }
    }
    public void OccupyCell(int x, int y)
    {
        if (IsWithinBounds(x, y))
        {
            map[x, y].IsOccupied = true;
        }
        else
        {
            throw new ArgumentOutOfRangeException($"La posición ({x}, {y}) está fuera de los límites del mapa.");
        }
    }

    public void PonerEntidad(int x, int y, IMapEntidad entity)
    {
        //map[x, y].Entity = entity;
        if (!IsWithinBounds(x, y)) return;
        
        var cell = map [x, y];
        cell.Entity = entity;
        cell.IsOccupied = true;
        cell.EntityType = entity.GetType().Name;

        if (entity is Quary recurso)
        {
            cell.Resource = recurso;
        }
    }
}