namespace ClassLibrary1.FacadeDirectory
{
    public interface IFacade
    {
        Map GenerateMap();
        void InitializePlayers();

        void GenerateCivicCenter(Map map, Player player, (int x, int y) position);
        void GenerateVillagers(Map map, Player player, (int x, int y) startPosition);
        void GenerateQuarries(Map map);

        Player PlayerOne { get; }
        Player PlayerTwo { get; }
    }
}