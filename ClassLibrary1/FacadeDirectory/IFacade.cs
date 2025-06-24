using ClassLibrary1.MapDirectory;


namespace ClassLibrary1.CivilizationDirectory


{
    public interface IFacade      
    {
        Map GenerateMap();
        void GenerateQuary(Map map);
        void GenerateVillagers(Map map);
        void GenerateCivicCenter(Map map);
        void InitializePlayer(Map map);
    }
} 