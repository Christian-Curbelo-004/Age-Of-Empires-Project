using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using ClassLibrary1.UnitsDirectory;
using ClassLibrary1.LogicDirectory;
using CreateBuildings;


namespace ClassLibrary1.FacadeDirectory
{
    public class GameFacade : IFacade
    {
        private string _messageProgram = Menu.WelcomeMessage() + "\n" + Menu.MenuScreen();
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        private readonly Random _random = new Random();

        public string MenuProgram()
        {
            return _messageProgram;
        }

        public Map GenerateMap()
        {
            return new Map(100, 100); // Mapa 100x100
        }

        public void GenerateQuary(Map map)
        {
            throw new NotImplementedException();
        }
        
        public void GenerateCivicCenter(Map map)
        {
            var civic = new CivicCenter
            {
                OwnerId = PlayerOne.Id,
                Position = (10, 10),
            };
            PlayerOne.Buildings.Add(civic);
            TryPlaceEntityNearby(map, civic, 10, 10);
        }

        public void GenerateCivicCenter2(Map map)
        {
            var civic = new CivicCenter
            {
                OwnerId = PlayerTwo.Id,
                Position = (90, 90)
            };
            PlayerTwo.Buildings.Add(civic);
            TryPlaceEntityNearby(map, civic, 90, 90);
        }

        public void GenerateVillagers(Map map)
        {
            for (int i = 0; i < 3; i++)
            {
                var villager = new Villagers(12, 3, PlayerOne.Id, 5)
                {
                    Position = (12 + i, 12)
                };
                PlayerOne.Units.Add(villager);
                TryPlaceEntityNearby(map, villager, 12 + i, 12);
            }
        }

        public void GenerateVillagers2(Map map)
        {
            for (int i = 0; i < 3; i++)
            {
                var villager = new Villagers(12, 3, PlayerTwo.Id, 8)
                {
                    Position = (88 + i, 88)
                };
                PlayerTwo.Units.Add(villager);
                TryPlaceEntityNearby(map, villager, 88 + i, 88);
            }
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
        }

        public string Attack(ICharacter attacker, ICharacter target)
        {
            int vidaObjetivo = CombatLogic.Damage(attacker, target);
            string mensaje = $"La vida restante del objetivo es {vidaObjetivo}";

            if (vidaObjetivo < 0)
                mensaje += ". El objetivo ha sido derrotado";
            return mensaje;
        }
        public async Task BuildBuildingWithAsync(Buildings buildings, Map map, int x, int y, Player player)
        {
            Constructor constructor = new Constructor();
            await constructor.BuildEstructura(buildings, map, x, y, player);
        }

        public void GenerateFarm(Map map, int x, int y)
        {
            var farm = new Farm(0, 100, 10, 1) { Position = (x, y) };
            TryPlaceEntityNearby(map, farm, x, y);
        }

        public void GenerateForest(Map map, int x, int y)
        {
            var forest = new Forest(0, 100, 10, 1) { Position = (x, y) };
            TryPlaceEntityNearby(map, forest, x, y);
        }

        public void GenerateGoldMine(Map map, int x, int y)
        {
            var gold = new GoldMine(0, 100, 10, 1) { Position = (x, y) };
            TryPlaceEntityNearby(map, gold, x, y);
        }

        public void GenerateStoneMine(Map map, int x, int y)
        {
            var stone = new StoneMine(0, 100, 10, 1) { Position = (x, y) };
            TryPlaceEntityNearby(map, stone, x, y);
        }
    }
}

