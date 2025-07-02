using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.UnitsDirectory;

namespace ClassLibrary1
{
    public class ShowScreen
    {
        private readonly Map _map;
        private readonly Player _playerOne;

        public ShowScreen(Map map, Player playerOne)
        {
            _map = map;
            _playerOne = playerOne;
        }

        // Devuelve todo el estado del juego en un string para enviar en Discord
        public string Screen()
        {
            var sb = new StringBuilder();

            // Mapa (texto plano)
            sb.AppendLine("==== MAPA ====");
            PrintMap printMap = new PrintMap(_map);
            sb.AppendLine(printMap.DisplayMap());

            // Población
            sb.AppendLine("\n==== POBLACIÓN ====");
            sb.AppendLine($"Población actual: {_playerOne.CurrentPoblacion} / {_playerOne.MaxPoblacion}");

            // Detalle de unidades por tipo
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

            // Recursos en el mapa
            sb.AppendLine("\n==== RECURSOS EN EL MAPA ====");
            var recursos = GetInfoResources();
            if (recursos.Count == 0)
            {
                sb.AppendLine(" - No hay recursos en el mapa.");
            }
            else
            {
                foreach (var recurso in recursos)
                {
                    sb.AppendLine($" - {recurso}");
                }
            }

            // Estado del centro cívico
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

        // Devuelve lista con info de recursos en el mapa
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

        // Opcional: devuelve string con tasa de recolección para mostrar en Discord
        public string ShowRecolectionResourceMuf(GameFacade gameFacade)
        {
            var ResourceMug = gameFacade.TasaRecoleccionRecurso();

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