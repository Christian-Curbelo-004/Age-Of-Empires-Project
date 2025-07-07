namespace ClassLibrary1.CivilizationDirectory
{
    /// <summary>
    /// Clase que maneja las peleas entre unidades.
    /// </summary>
    public class Fights
    {
        /// <summary>
        /// Realiza un combate entre un atacante y un objetivo, devolviendo el historial del combate.
        /// </summary>
        /// <param name="attacker">La unidad atacante.</param>
        /// <param name="target">La unidad objetivo.</param>
        /// <returns>Lista de cadenas que describen los eventos ocurridos durante el combate.</returns>
        public List<string> Combats(ICharacter attacker, ICharacter target)
        {
            List<string> historialCombate = new List<string>();

            int damage = attacker.Attack(target);
            historialCombate.Add($"{attacker.GetType().Name} atacó a {target.GetType().Name} y le pegó {damage}");

            if (target.Life <= 0)
            {
                historialCombate.Add($"{target.GetType().Name} murió");
            }
            else
            {
                historialCombate.Add($"{target.GetType().Name} tiene {target.Life} de vida");
            }

            return historialCombate;
        }
    }
}