using System;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.QuaryDirectory;
using QuaryBiome;
using CreateBuildings;

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
                case "atacar":
                    await MoveAndAttackAsync(obj, parameter);
                    break;
                default:
                    Console.WriteLine($"Verbo desconocido: {verb}");
                    break;
            }
        }

        private async Task MoveEntityAsync(string entityType, string parameter)
        {
            var coords = parameter.Split(',');
            if (coords.Length != 2 || !int.TryParse(coords[0], out int targetX) || !int.TryParse(coords[1], out int targetY))
            {
                Console.WriteLine("Los parámetros para 'mover' deben ser coordenadas en el formato 'x,y'.");
                return;
            }
            if (!_map.IsWithinBounds(targetX, targetY))
            {
                Console.WriteLine($"La posición ({targetX}, {targetY}) está fuera de los límites del mapa.");
                return;
            }

            var cell = _map.map.Cast<Cell>().FirstOrDefault(c => c.EntityType == entityType);
            if (cell == null)
            {
                Console.WriteLine($"No se encontró ninguna entidad de tipo {entityType} para mover.");
                return;
            }

            int currentX = cell.PosX;
            int currentY = cell.PosY;

            Console.WriteLine($"Iniciando movimiento de {entityType} desde ({currentX}, {currentY}) hacia ({targetX}, {targetY}).");

            while (currentX != targetX || currentY != targetY)
            {
                if (currentX < targetX) currentX++;
                else if (currentX > targetX) currentX--;

                if (currentY < targetY) currentY++;
                else if (currentY > targetY) currentY--;

            
                int moveTime = 1000 / cell.Speed;
                Console.WriteLine($"Moviendo {entityType} a la posición ({currentX}, {currentY})... Tiempo estimado: {moveTime / 1000.0} segundos.");
                await Task.Delay(moveTime);

             
                _map.map[cell.PosX, cell.PosY].EntityType = null; 
                _map.map[cell.PosX, cell.PosY].IsOccupied = false;

                cell.PosX = currentX;
                cell.PosY = currentY;

                _map.map[currentX, currentY].EntityType = entityType;
                _map.map[currentX, currentY].IsOccupied = true;

                Console.WriteLine($"{entityType} ha llegado a la posición ({currentX}, {currentY}).");
            }

            Console.WriteLine($"El movimiento de {entityType} a la posición ({targetX}, {targetY}) se ha completado.");
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

        private async Task MoveAndAttackAsync(string entityType, string parameter)
        {
            await MoveEntityAsync(entityType, parameter);
            var coords = parameter.Split(',');
            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);
            var cell = _map.map[x, y];

            var attacker = _map.map.Cast<Cell>().First(c => c.EntityType == entityType).Entity as ICharacter;

            if (attacker == null)
            {
                Console.WriteLine($"La entidad atacante no es válida.");
                return;
            }

            if (cell.Entity is ICharacter target)
            {
                Console.WriteLine($"El {entityType} está atacando a una tropa enemiga en ({x}, {y})...");
                await Task.Delay(2000);
                int damageDone = attacker.Attack(target);
                Console.WriteLine($"El daño infligido por {entityType} es: {damageDone}. Vida restante del enemigo: {target.Life}.");
            }
            else if (cell.Entity is Buildings building)
            {
                Console.WriteLine($"El {entityType} está atacando a una estructura enemiga en ({x}, {y})...");
                await Task.Delay(2000);
                building.Endurence -= attacker.AttackValue;
                Console.WriteLine($"El daño infligido por {entityType} es: {attacker.AttackValue}. Resistencia restante de la estructura: {building.Endurence}.");
            }
            else
            {
                Console.WriteLine($"No hay un objetivo válido para atacar en ({x}, {y}).");
            }
        }
    }
}