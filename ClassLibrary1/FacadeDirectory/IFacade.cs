namespace ClassLibrary1
{
    public interface IFacade      
    {
        void GenerateMap(Map map);
        void GenerateQuary(Map map);
        void GenerateVillagers(Map map);
        void GenerateCivicCenter(Map map);
        void InitializePlayer(Map map);
    }
} 