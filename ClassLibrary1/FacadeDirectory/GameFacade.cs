using System.Collections.Generic;
using CivicCenterNamespace;
using ClassLibrary1; 
namespace ClassLibrary1
{
    public class GameFacade : IFacade
    {
        public void GenerateMap()
        {
            Random random = new Random();
            Map map = new Map(100, 100);
        }


        public void GenerateQuary(PlayerOne playerOne)
        {
            Random random = new Random();
            Quary StoneQuary = new Quary(
                collectiontimeleft: random.Next(5, 10),
                collectionValue: 0,
                collectionType: "Stone"
            );
            playerOne.AddQuary(StoneQuary);
            
            Quary GoldQuary = new Quary(
                collectiontimeleft: random.Next(7, 15),
                collectionValue: 0,
                collectionType: "Gold"
            );
            playerOne.AddQuary(GoldQuary);
            
            Quary WoodQuary = new Quary(
                collectiontimeleft: random.Next(4, 9),
                collectionValue: 0,
                collectionType: "Wood"
            );
            playerOne.AddQuary(WoodQuary);  
            
        }

        public void GenerateVillagers(PlayerOne playerOne)
        {
            playerOne.AddVillagers(new Villagers(100, 1));
            playerOne.AddVillagers(new Villagers(100, 1));
            playerOne.AddVillagers(new Villagers(100, 1));
        }

        public void TrainSoldiers(PlayerOne playerOne)
        {
        }

        public void GenerateCivicCenter()
        {
        }

        public void GenerateVillagers()
        {
            
        }

        public void TrainSoldiers()
        {
        }

        public void InitializePlayer()
        {
            int Food = 100;
            int Wood = 100;
        }
    }
}