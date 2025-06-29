using ClassLibrary1.BuildingsDirectory;

namespace ClassLibrary1.MapDirectory;

public class CivicCenterChecker
{
    private readonly Map map;

    public CivicCenterChecker(Map map)
    {
        this.map = map;
    }

    public int CountCivicCenters(int ownerId)
    {
        int counter = 0;

        foreach (var cell in map.Cells)
        {
            if (!cell.IsOccupied || cell.Entity == null)
            {
                continue;
            }

            var entity = cell.Entity;
            if (entity is CivicCenter && entity.OwnerId == ownerId)
            {
                counter++;
            }
        }

        return counter;
    }
}