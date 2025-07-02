using System.Text;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.LogicDirectory;
using ClassLibrary1.MapDirectory;


namespace ClassLibrary1
{
    public class ShowScreen
    {
        private readonly Map _map;
        private readonly Player _playerOne;
        private readonly ResourceInventory _resourceInventory;

        public ShowScreen(Map map, Player playerOne)
        {
            _map = map;
            _playerOne = playerOne;
        }

        public string Screen()
        {
            var sb = new StringBuilder();

            sb.AppendLine("==== MAPA ====");
            PrintMap printMap = new PrintMap(_map);
            sb.AppendLine(printMap.DisplayMap());

            sb.AppendLine("\n==== POBLACIÓN ====");
            sb.AppendLine($"Población actual: {_playerOne.CurrentPoblacion} / {_playerOne.MaxPoblacion}");

            sb.AppendLine("\nUnidades del jugador:");
            var unidades = _playerOne.Units
                .GroupBy(u => u.GetType().Name)
                .ToDictionary(g => g.Key, g => g.Count());

            if (unidades.Count == 0)
            {
                sb.AppendLine(" - No tienes unidades actualmente.");
            }
            else
            {
                foreach (var kvp in unidades)
                {
                    sb.AppendLine($" - {kvp.Key}: {kvp.Value}");
                }
            }

            sb.AppendLine("\n==== RECURSOS DEL JUGADOR ====");
            if (_playerOne.Resources == null)
            {
                sb.AppendLine(" - No tienes recursos.");
            }
            else
            {
                sb.AppendLine($" - Madera: {_playerOne.Resources.Wood}");
                sb.AppendLine($" - Alimento: {_playerOne.Resources.Food}");
                sb.AppendLine($" - Oro: {_playerOne.Resources.Gold}");
                sb.AppendLine($" - Piedra: {_playerOne.Resources.Stone}");
            }
            int actualHealth = _playerOne.CivicCenter?.ActualHealth ?? 0;
            int maxHealth = CivicCenter.MaxHealth;

            sb.AppendLine("\n==== ESTADO DEL CENTRO CÍVICO ====");
            if (actualHealth <= 0)
            {
                sb.AppendLine("¡Has perdido el centro cívico! (Game Over)");
            }
            else if (actualHealth <= maxHealth * 0.10)
            {
                sb.AppendLine("¡Advertencia! Tu centro cívico está en peligro.");
                sb.AppendLine($"Vida: {actualHealth} / {maxHealth}");
            }
            else
            {
                sb.AppendLine($"Vida: {actualHealth} / {maxHealth}");
                sb.AppendLine("Estado saludable.");
            }

            return sb.ToString();
        }

        public List<string> GetInfoResources()
        {
            List<string> Resources = new List<string>();
            foreach (Deposit deposit in _map.GetEntities<Deposit>())
            {
                string resourceAmount = $"{deposit.GetType().Name} tiene {deposit.ActualResources()} de {deposit.MaxCapacity}";
                Resources.Add(resourceAmount);
            }

            return Resources;
        }

        public string ShowRecolectionResourceMuf(GameFacade gameFacade)
        {
            var ResourceMug = _resourceInventory.TasaRecoleccionRecurso();

            var sb = new StringBuilder();
            sb.AppendLine("Tasa de recolección de recursos:");
            foreach (var recolect in ResourceMug)
            {
                sb.AppendLine($"{recolect.Key} : {recolect.Value}");
            }

            return sb.ToString();
        }
    }
}
