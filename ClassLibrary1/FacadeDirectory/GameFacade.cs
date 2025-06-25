using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;
using ClassLibrary1.UnitsDirectory;
using ClassLibrary1.LogicDirectory;
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

        public void GenerateQuary(Map map)
        {
            throw new NotImplementedException();
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

        public void GenerateGoldMine(Map map)
        {
            var goldMine = new GoldMine(
                ownerId: PlayerOne.Id,
                initialGold: 300,
                extractionRate: _random.Next(5, 10),
                collectionValue: 5
            );

            goldMine.Position = (20, 5);

            map.PlaceEntity(goldMine, 20, 5);
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
            GenerateGoldMine(map);
            GenerateVillagers(map);
        }
        public void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height, int cantidadrecursos)
        {
            Random random = new Random();
            for (int i = 0; i < cantidadrecursos; i++)
            {
                int x = random.Next(inicialX, inicialX + width);
                int y = random.Next(inicialY, inicialY + height);

                int recurso = random.Next(3);
                IMapEntity entity;

                if (recurso == 0)
                    entity = new Forest(5, 0, 50, 150);
                else if (recurso == 1)
                    entity = new GoldMine(5, 0, 50, 50);
                else
                    entity = new StoneMine(5, 0, 50, 75);

                map.PlaceEntity(entity,x,y);
            }
        }
    }
    
}