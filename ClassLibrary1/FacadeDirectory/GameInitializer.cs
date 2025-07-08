using ClassLibrary1.FacadeDirectory;
public class GameInitializer
{
    private readonly Map _map;
    private readonly IFacade _facade;

    public GameInitializer(IFacade facade, Map map)
    {
        _facade = facade;
        _map = map;
    }

    public void SetupGame()
    {
        _facade.InitializePlayers();
        PlaceStartingBuildings();
        PlaceStartingUnits();
        PlaceStartingQuarries();
    }

    private void PlaceStartingBuildings()
    {
        _facade.GenerateCivicCenter(_map, _facade.PlayerOne, GameConfig.PlayerOneStart);
        _facade.GenerateCivicCenter(_map, _facade.PlayerTwo, GameConfig.PlayerTwoStart);
    }

    private void PlaceStartingUnits()
    {
        _facade.GenerateVillagers(_map, _facade.PlayerOne, GameConfig.PlayerOneVillagerStart);
        _facade.GenerateVillagers(_map, _facade.PlayerTwo, GameConfig.PlayerTwoVillagerStart);
    }

    private void PlaceStartingQuarries()
    {
        _facade.GenerateQuarries(_map);
    }
}