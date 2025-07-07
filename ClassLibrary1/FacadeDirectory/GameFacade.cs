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

        public void InitializePlayers()
        {
            PlayerOne = new Player(123, "Roman", 50)
            {
                Id = 1,
                StartingPosition = GameConfig.PlayerOneStart,
                Buildings = new List<Buildings>(),
                Units = new List<IMapEntity>(),
            };

            PlayerTwo = new Player(124, "Vikings", 50)
            {
                Id = 2,
                StartingPosition = GameConfig.PlayerTwoStart,
                Buildings = new List<Buildings>(),
                Units = new List<IMapEntity>(),
            };

            PlayerOne.Resources.Wood = GameConfig.InitialWood;
            PlayerOne.Resources.Food = GameConfig.InitialFood;
            PlayerOne.Resources.Gold = GameConfig.InitialGold;
            PlayerOne.Resources.Stone = GameConfig.InitialStone;

            PlayerTwo.Resources.Wood = GameConfig.InitialWood;
            PlayerTwo.Resources.Food = GameConfig.InitialFood;
            PlayerTwo.Resources.Gold = GameConfig.InitialGold;
            PlayerTwo.Resources.Stone = GameConfig.InitialStone;
        }

        public void GenerateCivicCenter(Map map, Player player, (int x, int y) position)
        {
            var civic = new CivicCenter(500, 0, "Civic Center", player.Id) { OwnerId = player.Id };
            if (map.PlaceEntity(civic, position.x, position.y))
                player.Buildings.Add(civic);
        }

        public void GenerateVillagers(Map map, Player player, (int x, int y) startPosition)
        {
            for (int i = 0; i < 3; i++)
            {
                var villager = new Villagers(100, 2, player.Id, 5);
                int x = startPosition.x + i;
                int y = startPosition.y;

                if (map.PlaceEntity(villager, x, y))
                    player.Units.Add(villager);
            }
        }

        public void GenerateQuarries(Map map)
        {
            var goldMine = new GoldMine(0, 0, 300, 1, 1, PlayerOne.Id, new ResourceCollector());
            map.PlaceEntity(goldMine, GameConfig.GoldMinePos.x, GameConfig.GoldMinePos.y);

            var stoneMine = new StoneMine(0, 0, 300, 1, 1, PlayerOne.Id, new ResourceCollector());
            map.PlaceEntity(stoneMine, GameConfig.StoneMinePos.x, GameConfig.StoneMinePos.y);

            var forest = new Forest(0, 0, 300, 1, 1, PlayerOne.Id, new ResourceCollector());
            map.PlaceEntity(forest, GameConfig.ForestPos.x, GameConfig.ForestPos.y);

            var farm = new Farm(0, 0, 300, 1, 1, PlayerOne.Id, new ResourceCollector());
            map.PlaceEntity(farm, GameConfig.FarmPos.x, GameConfig.FarmPos.y);
        }
    }
}


