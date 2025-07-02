//using ClassLibrary1.FacadeDirectory;
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
        private string _messageProgram = Menu.WelcomeMessage() + "/n" + Menu.MenuScreen();
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
            PlayerOne.Buildings.Equals(civic);
            map.PlaceEntity(civic, 10, 10);
        }

        public void GenerateCivicCenter2(Map map)
        {
            var civic = new CivicCenter
            {
                OwnerId = PlayerTwo.Id,
                Position = (90, 90)
            };

            PlayerTwo.Buildings.Equals(civic);
            map.PlaceEntity(civic, 90, 90);
        }

        public void GenerateVillagers(Map map)
        {
            for (int i = 0; i < 3; i++)
            {
                var villager = new Villagers(12, 3, 123, 5)
                {
                    Position = (12 + i, 12)
                };

                PlayerOne.Units.Equals(villager);
                map.PlaceEntity(villager, 12 + i, 12);
            }
        }

        public void GenerateVillagers2(Map map)
        {
            for (int i = 0; i < 3; i++)
            {
                var villager = new Villagers(12, 3, 123, 8)
                {
                    Position = (88 + i, 88)
                };

                PlayerOne.Units.Equals(villager);
                map.PlaceEntity(villager, 12 + i, 12);
            }
        }

        public void InitializePlayer(Map map)
        {
            PlayerOne = new Player(123, "", 50)
            {
                Id = 1,
                Civilization = new string("Roman"), // Reemplaza por tu civilizaciÃ³n concreta
                StartingPosition = (10, 10),
                Buildings = new List<Buildings>(),
                Units = new List<Units>()
            };
            PlayerTwo = new Player(124,"", 50)
            {
                Id = 2,
                Civilization = new string("Vikings"), // Reemplaza por tu civilizaciÃ³n concreta
                StartingPosition = (90, 90),
                Buildings = new List<Buildings>(),
                Units = new List<Units>()
            };

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
                mensaje += "El objetivo ha sido derrotado";
            return mensaje;

            // en el test, string resultado = GameFacade.Attack(attacker, target)
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

                map.PlaceEntity(entity, x, y);
            }
        }

        public Dictionary<string, int>
            TasaRecoleccionRecurso() //para poder mostrar tasa de recoleccion por tipo de recurso
        {
            var tasarecurso = new Dictionary<string, int>()
            {
                { "gold", 4 }, { "stone", 5 }, { "wood", 6 }, { "food", 5 }
            };
            return tasarecurso;
        }

        public async Task BuildBuildingWithAsync(Buildings buildings, Map map, int x, int y, Player player)
        {
            Constructor constructor = new Constructor();
            await constructor.BuildEstructura(buildings, map, x, y, player);
        }


        public void GenerateFarm(Map map, int x, int y) // ya se que figura como metodo, hay que completarlo
        {
            var farm = new Farm(0, 100, 10, 1) { Position = (x, y) };
            map.PlaceEntity(farm, x, y);
        }

        public void GenerateForest(Map map, int x, int y)
        {
            var forest = new Forest(0, 100, 10, 1) { Position = (x, y) };
            map.PlaceEntity(forest, x, y);
        }

        public void GenerateGoldMine(Map map, int x, int y)
        {
            var  gold = new GoldMine(0, 100, 10, 1) { Position = (x, y) };
            map.PlaceEntity(gold, x, y);
        }

        public void GenerateStoneMine(Map map, int x, int y)
        {
            var stone = new StoneMine(0, 100, 10, 1) { Position = (x, y) };
        }
    }   
}