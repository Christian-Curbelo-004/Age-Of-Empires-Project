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

        // Método que intenta colocar la entidad en (x,y), y si está ocupada busca cerca (radio máximo 5)
        private bool TryPlaceEntityNearby(Map map, IMapEntity entity, int x, int y, int maxRadius = 5)
        {
            // Primero intenta en la posición original
            if (TryPlaceEntity(map, entity, x, y))
                return true;

            // Busca celdas alrededor en expansión de radio
            for (int radius = 1; radius <= maxRadius; radius++)
            {
                for (int dx = -radius; dx <= radius; dx++)
                {
                    for (int dy = -radius; dy <= radius; dy++)
                    {
                        int newX = x + dx;
                        int newY = y + dy;
                        if (newX == x && newY == y)
                            continue;

                        if (newX >= 0 && newY >= 0 && newX < map.Cells.GetLength(0) && newY < map.Cells.GetLength(1))
                        {
                            if (TryPlaceEntity(map, entity, newX, newY))
                                return true;
                        }
                    }
                }
            }

            Console.WriteLine($"No se pudo colocar la entidad cerca de ({x},{y}).");
            return false;
        }

        // Método que verifica si la celda está libre y coloca la entidad
        private bool TryPlaceEntity(Map map, IMapEntity entity, int x, int y)
        {
            if (x < 0 || y < 0 || x >= map.Cells.GetLength(0) || y >= map.Cells.GetLength(1))
                return false;

            var cell = map.Cells[x, y];
            if (!cell.IsOccupied)
            {
                map.PlaceEntity(entity, x, y);
                return true;
            }
            else
            {
                // Console.WriteLine($"La celda ({x},{y}) ya está ocupada por otra entidad.");
                return false;
            }
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

        public void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height, int cantidadrecursos)
        {
            int attemptsLimit = cantidadrecursos * 5;
            int placed = 0;
            int attempts = 0;

            while (placed < cantidadrecursos && attempts < attemptsLimit)
            {
                attempts++;
                int x = _random.Next(inicialX, inicialX + width);
                int y = _random.Next(inicialY, inicialY + height);

                int recurso = _random.Next(3);
                IMapEntity entity;

                if (recurso == 0)
                    entity = new Forest(5, 0, 50, 150);
                else if (recurso == 1)
                    entity = new GoldMine(5, 0, 50, 50);
                else
                    entity = new StoneMine(5, 0, 50, 75);

                if (TryPlaceEntityNearby(map, entity, x, y))
                    placed++;
            }

            if (placed < cantidadrecursos)
                Console.WriteLine($"Solo se colocaron {placed} recursos de {cantidadrecursos} solicitados en la zona.");
        }

        public Dictionary<string, int> TasaRecoleccionRecurso()
        {
            return new Dictionary<string, int>()
            {
                { "gold", 4 }, { "stone", 5 }, { "wood", 6 }, { "food", 5 }
            };
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

