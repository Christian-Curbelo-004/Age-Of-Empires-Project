using System;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.QuaryDirectory;
using QuaryBiome;

namespace ClassLibrary1
{
    public class CommandProcessor
    {
        private Map _map;
        public CommandProcessor(Map map)
        {
            _map = map;
        }
        public async void ProcessCommand(string command)
        {
            var parts = command.Split('+');
            if (parts.Length < 3)
            {
                Console.WriteLine("El comando no es válido. Debe tener el formato 'verbo+objeto+parámetro'.");
                return;
            }

            string verb = parts[0].ToLower();
            string obj = parts[1];
            string parameter = parts[2];

            switch (verb)
            {
                case "mover":
                    await MoveEntityAsync(obj, parameter);
                    break;
                case "talar":
                    await MoveAndChopAsync(obj, parameter);
                    break;
                case "minar":
                    await MoveAndMineAsync(obj, parameter);
                    break;
                default:
                    Console.WriteLine($"Verbo desconocido: {verb}");
                    break;
            }
        }
        private async Task MoveEntityAsync(string entityType, string parameter)
        {
            var coords = parameter.Split(',');
            if (coords.Length != 2 || !int.TryParse(coords[0], out int x) || !int.TryParse(coords[1], out int y))
            {
                Console.WriteLine("Los parámetros para 'mover' deben ser coordenadas en el formato 'x,y'.");
                return;
            }
            if (!_map.IsWithinBounds(x, y))
            {
                Console.WriteLine($"La posición ({x}, {y}) está fuera de los límites del mapa.");
                return;
            }
            var cell = _map.map.Cast<Cell>().FirstOrDefault(c => c.EntityType == entityType);
            if (cell == null)
            {
                Console.WriteLine($"No se encontró ninguna entidad de tipo {entityType} para mover.");
                return;
            }
            int distance = Math.Abs(cell.PosX - x) + Math.Abs(cell.PosY - y);
            int moveTime = distance * (1000 / cell.Speed);
            Console.WriteLine(
                $"Moviendo {entityType} a la posición ({x}, {y})... Tiempo estimado: {moveTime / 1000} segundos.");
            await Task.Delay(moveTime);
            cell.EntityType = null;
            cell.IsOccupied = false;
            _map.map[x, y].EntityType = entityType;
            _map.map[x, y].IsOccupied = true;
            Console.WriteLine($"{entityType} ha llegado a la posición ({x}, {y}).");
        }
        private async Task MoveAndChopAsync(string entityType, string parameter)
        {
            await MoveEntityAsync(entityType, parameter);
            var coords = parameter.Split(',');
            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);
            var cell = _map.map[x, y];
            if (cell.Resource is Forest forest)
            {
                Console.WriteLine($"El {entityType} está talando en ({x}, {y})...");
                await Task.Delay(3000); 
                int resourcesCollected = forest.GetResources();
                Console.WriteLine($"El {entityType} ha recolectado {resourcesCollected} unidades de madera.");
            }
            else
            {
                Console.WriteLine($"No hay un bosque válido para talar en ({x}, {y}).");
            }
        }
        private async Task MoveAndMineAsync(string entityType, string parameter)
        {
            await MoveEntityAsync(entityType, parameter);
            var coords = parameter.Split(',');
            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);
            var cell = _map.map[x, y];
            if (cell.Resource is GoldMine goldMine)
            {
                Console.WriteLine($"El {entityType} está minando oro en ({x}, {y})...");
                await Task.Delay(3000); 
                int resourcesCollected = goldMine.GetResources(); 
                Console.WriteLine($"El {entityType} ha recolectado {resourcesCollected} unidades de oro.");
            }
            else if (cell.Resource is StoneMine stoneMine)
            {
                Console.WriteLine($"El {entityType} está minando piedra en ({x}, {y})...");
                await Task.Delay(3000); 
                int resourcesCollected = stoneMine.GetResources(); 
                Console.WriteLine($"El {entityType} ha recolectado {resourcesCollected} unidades de piedra.");
            }
            else
            {
                Console.WriteLine($"No hay una mina válida para minar en ({x}, {y}).");
            }
        }
    }
}