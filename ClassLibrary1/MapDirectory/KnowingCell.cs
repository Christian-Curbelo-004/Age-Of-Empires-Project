using ClassLibrary1.BuildingsDirectory;

namespace ClassLibrary1.MapDirectory;

public class KnowingCell
{
    private readonly Map map;

    public KnowingCell(Map map)
    {
        this.map = map;
    }

    public void CheckPopulation(int ownerId)
    {
        int maxCapacity = 0;
        int occupied = 0;

        foreach (var cell in map.Cells)
        {
            if (!cell.IsOccupied || cell.Entity == null)
            {
                continue;
            }

            var entity = cell.Entity;
            if (entity is ICapacity capacityEntity && entity.OwnerId == ownerId)
            {
                maxCapacity += capacityEntity.Capacity;
            }
        }
        Console.WriteLine($"El jugador {ownerId} tiene {maxCapacity} de capacidad");
    }
    public void CheckCivicCenter(int ownerID)
    {
        int CounterCivicCenter = 0;

        foreach (var cell in map.Cells)
        {
            if (!cell.IsOccupied || cell.Entity == null)
            {
                continue;
            }

            var entity = cell.Entity;
            if (entity is CivicCenter civicCenter && entity.OwnerId == ownerID)
            {
                CounterCivicCenter += 1;
            }
        }
    }
}

