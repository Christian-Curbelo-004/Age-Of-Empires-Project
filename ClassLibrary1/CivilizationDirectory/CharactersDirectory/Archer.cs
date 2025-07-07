using ClassLibrary1.MapDirectory;
using ClassLibrary1.UnitsDirectory;

namespace ClassLibrary1.CivilizationDirectory
{
    
    /// <summary>
    /// Representa una unidad arquera, que hereda de <see cref="Soldier"/>.
    /// </summary>
    public class Archer : Soldier, IMapEntity
    {
        public string Symbol { get; set; } = "Ar";
        public override string ToString()
        {
            return $"{Symbol}{OwnerId}"; 
        }
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Archer"/> con valores predeterminados de vida, ataque y defensa.
        /// </summary>
        public Archer() : base(100, 20, 10, 10)
        {
        }

        /// <summary>
        /// Realiza un ataque a un objetivo especificado.
        /// </summary>
        /// <param name="target">La unidad objetivo que recibirá el ataque.</param>
        /// <returns>El daño recibido por el objetivo después del ataque.</returns>
        public override int Attack(ICharacter target)
        {
            return target.RecieveAttack(AttackValue);
        }

        /// <summary>
        /// Recibe un ataque y disminuye la vida en consecuencia.
        /// </summary>
        /// <param name="damage">Cantidad de daño recibido.</param>
        /// <returns>La vida restante después del ataque.</returns>
        public override int RecieveAttack(int damage)
        {
            Life -= damage;
            return Life;
        }
    }
}