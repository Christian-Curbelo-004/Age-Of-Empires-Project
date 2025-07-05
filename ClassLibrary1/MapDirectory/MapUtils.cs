using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;

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

    public static int ColocarRecursosEnEsquina(Map map, int inicialX, int inicialY, int width, int height, int cantidadRecursos, Random random)
    {
        int attemptsLimit = cantidadRecursos * 5;
        int placed = 0;
        int attempts = 0;

        while (placed < cantidadRecursos && attempts < attemptsLimit)
        {
            attempts++;
            int x = random.Next(inicialX, inicialX + width);
            int y = random.Next(inicialY, inicialY + height);

            IMapEntity entity = random.Next(3) switch
            {
                // Arreglar después de lo de Getresources
                //0 => new Forest(5, 0, 50, 150),
                //1 => new GoldMine(5, 0, 50, 50),
                //_ => new StoneMine(5, 0, 50, 75),
            };

            if (TryPlaceEntityNearby(map, entity, x, y))
                placed++;
        }

        return placed; // Devolvés cuántos se colocaron correctamente
    }
}