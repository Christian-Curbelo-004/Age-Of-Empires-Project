using CommandDirectory;

namespace ClassLibrary1.CommandDirectory;

public class BuildCommand : IPlayerCommand
{
    private readonly IMapService _mapService;

    public BuildCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task<string> ExecuteAsync(string entityType, string destination, Player player)
    {
        return await _mapService.BuildAsync(entityType, destination, player);
    }

    // Compatibilidad con IGameCommand
    public async Task<string> ExecuteAsync(string entityType, string destination)
    {
        return "Este comando requiere un jugador.";
    }
}