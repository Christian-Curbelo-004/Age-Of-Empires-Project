namespace ClassLibrary1
{
    public interface IFacade      
    {
        void GenerateMap(PlayerOne playerOne);
        void GenerateQuary(PlayerOne playerOne);
        void GenerateVillagers(PlayerOne playerOne);
        void GenerateCivicCenter(PlayerOne playerOne);
        void InitializePlayer(PlayerOne playerOne);
    }
}