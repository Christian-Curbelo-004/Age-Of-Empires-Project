using System;
using CivicCenterNamespace;
using ClassLibrary1.LogicDirectory;
using ClassLibrary1.CivilizationDirectory;
namespace ClassLibrary1
{
    public class GameFacade : IFacade
    {
        public void GenerateMap(Map map)
        {
            Random random = new Random();
            Map RandomMap = new Map(100, 100);
        }
        public void GenerateCivicCenter(Map map)
        {
            map.PlayerOne.CivicCenter = new CivicCenter(
                endurence: 100,
                constructiontimeleft: 10,
                name: "Centro Cívico",
                resourceValue: 50
            );
            map.PlayerTwo.CivicCenter = new CivicCenter(
                endurence: 100,
                constructiontimeleft: 10,
                name: "Centro Cívico",
                resourceValue: 50
            );
        }
        public void GenerateQuary(Map map)
        {
            Random random = new Random();
            
            Quary StoneQuary = new Quary(
                collectiontimeleft: random.Next(5, 10),
                collectionValue: 0,
                collectionType: "Stone"
            );
            map.PlayerOne.AddQuary(StoneQuary);
            map.PlayerTwo.AddQuary(StoneQuary);
            
            Quary GoldQuary = new Quary(
                collectiontimeleft: random.Next(7, 15),
                collectionValue: 0,
                collectionType: "Gold"
            );
           map.PlayerOne.AddQuary(GoldQuary);
           map.PlayerTwo.AddQuary(GoldQuary);
            
            Quary WoodQuary = new Quary(
                collectiontimeleft: random.Next(4, 9),
                collectionValue: 0,
                collectionType: "Wood"
            );
           map.PlayerOne.AddQuary(WoodQuary);
           map.PlayerTwo.AddQuary(WoodQuary);
        }
    
        

        public void GenerateVillagers(Map map)
        {
            for (int a = 0; a < 3; a++)
            {
                Villagers villagers = new Villagers(100, 10);
                map.PlayerOne.AddVillagers(villagers);
                map.PlayerTwo.AddVillagers(villagers);
            }
        }



        public void TrainSoldiers(Map map)
        {
            for (int s = 0; s < 3; s++)
            {
                Archer archer = new Archer();
                Paladin paladin = new Paladin();
                Raider raider = new Raider();
                // chivarly
                // centuries
            }
        }

        public void InitializePlayer(Map map)
        {
            map.PlayerOne.Food = 100;
            map.PlayerOne.Wood = 100;
            GenerateCivicCenter(map);
            GenerateVillagers(map);
        }
    }
}