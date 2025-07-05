using CommandDirectory;

namespace ClassLibrary1.CommandDirectory;

public class GatherFoodCommand : IGameCommand
{
    private readonly IMapService _mapService;

    public GatherFoodCommand(IMapService mapService)
    {
        _mapService = mapService;
    }

    public async Task<string> ExecuteAsync(string entityType, string destination)
    {
        return await _mapService.GatherFoodAsync(entityType, destination);
    }
}