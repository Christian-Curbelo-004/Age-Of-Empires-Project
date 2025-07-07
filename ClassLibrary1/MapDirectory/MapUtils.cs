using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using ClassLibrary1.UnitsDirectory;

public static class MapUtils
{
    public static bool TryPlaceEntity(Map map, IMapEntity entity, int x, int y)
    {
        if (!map.IsWithinBounds(x, y))
            return false;

        var cell = map.GetCell(x, y);
        if (!cell.IsOccupied)
        {
            return map.PlaceEntity(entity, x, y);
        }
        return false;
    }

    public static bool TryPlaceEntityNearby(Map map, IMapEntity entity, int x, int y, int maxRadius = 5)
    {
        if (TryPlaceEntity(map, entity, x, y))
            return true;

        for (int radius = 1; radius <= maxRadius; radius++)
        {
            for (int dx = -radius; dx <= radius; dx++)
            {
                for (int dy = -radius; dy <= radius; dy++)
                {
                    int newX = x + dx;
                    int newY = y + dy;

                    if (newX == x && newY == y)
                        continue;

                    if (map.IsWithinBounds(newX, newY) &&
                        TryPlaceEntity(map, entity, newX, newY))
                        return true;
                }
            }
        }

        return false;
    }

    public static int ColocarRecursosEnEsquina(Map map, int inicialX, int inicialY, int width, int height, int cantidadRecursos, Random random, int ownerId)
    {
        int attemptsLimit = cantidadRecursos * 5;
        int placed = 0;
        int attempts = 0;
        var collector = new Villagers(100, 1, ownerId, 3);

        while (placed < cantidadRecursos && attempts < attemptsLimit)
        {
            attempts++;
            int x = random.Next(inicialX, inicialX + width);
            int y = random.Next(inicialY, inicialY + height);

            IMapEntity entity = random.Next(4) switch
            {
                0 => new Forest(x, y, 300, 10, 5, ownerId, collector),
                1 => new GoldMine(x, y, 300, 10, 5, ownerId, collector),
                2 => new Farm(x,y,300,10,5,ownerId,collector),
                _ => new StoneMine(x, y, 300, 10, 5,ownerId,  collector)
            };

            if (TryPlaceEntityNearby(map, entity, x, y))
                placed++;
        }

        return placed;
    }
}