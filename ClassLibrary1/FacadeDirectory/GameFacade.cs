using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.UnitsDirectory;
using CreateBuildings;


namespace ClassLibrary1
{
    public class GameFacade : IFacade
    {
        public Player PlayerOne { get; private set; }
        private readonly Random _random = new Random();

        public Map GenerateMap()
        {
            return new Map(100, 100); // Mapa 100x100
        }

        public void GenerateCivicCenter(Map map)
        {
            var civic = new CivicCenter
            {
                OwnerId = PlayerOne.Id,
                Position = (10, 10)
            };

            PlayerOne.Buildings.Equals(civic);
            map.PlaceEntity(civic, 10, 10);
        }

        public void GenerateQuary(Map map)
        {
            var quary = new Quary
            {
                OwnerId = PlayerOne.Id,
                Position = (20, 5),
                Type = "Oro",
                ExtractionRate = _random.Next(5, 10)
            };

            map.PlaceEntity(quary, 20, 5);
        }

        public void GenerateVillagers(Map map)
        {
            for (int i = 0; i < 3; i++)
            {
                var villager = new Villagers( 12, 3,  123, PlayerOne.Id)
                {
                    Position = (12 + i, 12)
                };

                PlayerOne.Units.Equals(villager);
                map.PlaceEntity(villager, 12 + i, 12);
            }
        }
        public void InitializePlayer(Map map)
        {
            PlayerOne = new Player(123)
            {
                Id = 1,
                Civilization = new string("Roman"), // Reemplaza por tu civilizaciÃ³n concreta
                StartingPosition = (10, 10),
                Buildings = new List<Buildings>(),
                Units = new List<Units>()
            };

            GenerateCivicCenter(map);
            GenerateQuary(map);
            GenerateVillagers(map);
        }
    }

  
}