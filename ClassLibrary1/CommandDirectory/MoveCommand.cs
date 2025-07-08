using CommandDirectory;

public class MoveCommand : IPlayerCommand
{
    private readonly IMapService _mapService;

    public MoveCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task<string> ExecuteAsync(string entityType, string parameters, Player player)
    {
        var parts = parameters.Split('+');
        if (parts.Length != 3)
            return "Uso: !move+Tipo+Cantidad+Origen+Destino (Ej: !move+Villager+3+4,5+8,9 o !move+Villager+*+4,5+8,9)";

        int cantidad;

        if (parts[0] == "*")
        {
            cantidad = int.MaxValue; // Mover todas
        }
        else if (!int.TryParse(parts[0], out cantidad))
        {
            return "Cantidad inválida.";
        }

        var origen = ParseCoords(parts[1]);
        var destino = ParseCoords(parts[2]);

        return await _mapService.MoveEntitiesOfTypeAsync(entityType, cantidad, origen, destino, player.Id);
    }

    private (int x, int y) ParseCoords(string input)
    {
        var coords = input.Split(',');
        if (coords.Length != 2 || !int.TryParse(coords[0], out int x) || !int.TryParse(coords[1], out int y))
            throw new ArgumentException($"Coordenadas inválidas: {input}");
        return (x, y);
    }
}