using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using ClassLibrary1.UnitsDirectory;

namespace ClassLibrary1.FacadeDirectory
{
    public class GameFacade : IFacade
    {
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }

        public Map GenerateMap() => new Map(100, 100);

        public void GenerateCivicCenter(Map map)
        {
            if (PlayerOne == null) return;

            var civic = new CivicCenter(0, 0, "Civic Center", PlayerOne.Id)
            {
                OwnerId = PlayerOne.Id
            };

            if (map.PlaceEntity(civic, 10, 10))
                PlayerOne.Buildings.Add(civic);
        }

        public void GenerateCivicCenter2(Map map)
        {
            var civic = new CivicCenter(0, 0, "Civic Center", PlayerTwo.Id)
            {
                OwnerId = PlayerTwo.Id
            };

            if (map.PlaceEntity(civic, 90, 90))
                PlayerTwo.Buildings.Add(civic);
        }

        public void GenerateVillagers(Map map)
        {
            if (PlayerOne == null) return;
            for (int i = 0; i < 3; i++)
            {
                var villager = new Villagers(0, 0, PlayerOne.Id, 5);
                int x = 12 + i;
                int y = 12;

                if (map.PlaceEntity(villager, x, y))
                    PlayerOne.Units.Add(villager);
            }
        }

        public void GenerateVillagers2(Map map)
        {
            if (PlayerTwo == null) return;
            for (int i = 0; i < 3; i++)
            {
                var villager = new Villagers(0, 0, PlayerTwo.Id, 5);
                int x = 88 + i;
                int y = 88;

                if (map.PlaceEntity(villager, x, y))
                    PlayerTwo.Units.Add(villager);
            }
        }

        public void GenerateQuary(Map map)
        {
            var goldMine = new GoldMine(0, 0, 300,1, 1, PlayerOne.Id, new ResourceCollector());
            map.PlaceEntity(goldMine, 20, 20);

            var stoneMine = new StoneMine(0, 0, 300, 1, 1, PlayerOne.Id, new ResourceCollector());
            map.PlaceEntity(stoneMine, 25, 25);

            var forest = new Forest(0, 0, 300, 1, 1, PlayerOne.Id, new ResourceCollector());
            map.PlaceEntity(forest, 30, 30);
        }


        public void InitializePlayer(Map map)
        {
            PlayerOne = new Player(123, "Roman", 50)
            {
                Id = 1,
                StartingPosition = (10, 10),
                Buildings = new List<Buildings>(),
                Units = new List<IMapEntity>()
            };

            PlayerTwo = new Player(124, "Vikings", 50)
            {
                Id = 2,
                StartingPosition = (90, 90),
                Buildings = new List<Buildings>(),
                Units = new List<IMapEntity>()
            };

            PlayerOne.Resources.Wood = 100;
            PlayerOne.Resources.Food = 100;
            PlayerOne.Resources.Gold = 0;
            PlayerOne.Resources.Stone = 0;

            PlayerTwo.Resources.Wood = 100;
            PlayerTwo.Resources.Food = 100;
            PlayerTwo.Resources.Gold = 0;
            PlayerTwo.Resources.Stone = 0;

            GenerateCivicCenter(map);
            GenerateCivicCenter2(map);
            GenerateVillagers(map);
            GenerateVillagers2(map);
            GenerateQuary(map);
        }
        
    }
}

