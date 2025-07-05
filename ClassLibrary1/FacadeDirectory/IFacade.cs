namespace ClassLibrary1.FacadeDirectory


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