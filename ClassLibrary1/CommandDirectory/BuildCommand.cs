using CommandDirectory;

namespace ClassLibrary1.CommandDirectory;

public class BuildCommand : IGameCommand
{
    private readonly IMapService _mapService;
    private readonly Player _player;

    public BuildCommand(IMapService mapService, Player player)
    {
        _mapService = mapService;
        _player = player;
    }

    public async Task<string> ExecuteAsync(string buildingType, string destination)
    {
        string result = await _mapService.BuildAsync(buildingType, destination, _player);
        return result;
    }
}