using ClassLibrary1.MapDirectory;
using ClassLibrary1.QuaryDirectory;

/// <summary>
/// Representa un bosque en el mapa, que puede ser recolectado para obtener madera.
/// Hereda de <see cref="Quary"/> e implementa <see cref="IMapEntity"/>.
/// </summary>
public class Forest : Quary, IMapEntity
{
    /// <summary>
    /// Obtiene o establece el identificador del jugador propietario de forest.
    /// </summary>
    public int OwnerId { get; set; }

    /// <summary>
    /// establece la posición del bosque en el mapa.
    /// </summary>
    public (int X, int Y) Position { get; set; }

    /// <summary>
    /// nombre de la entidad "Forest".
    /// </summary>
    public string Name { get; set; } = "Forest";

    /// <summary>
    /// Tipo de recurso disponible en este depósito.
    /// </summary>
    public string ResourceType => "Wood";

    /// <summary>
    /// Cantidad actual de madera disponible en forest.
    /// </summary>
    public int Wood { get; private set; }

    /// <summary>
    /// Obtiene la cantidad actual de recurso disponible.
    /// Se mapea directamente a <see cref="Wood"/>.
    /// </summary>
    public int CurrentAmount
    {
        get => Wood;
        set => Wood = value;
    }

    /// <summary>
    /// calcula la cantidad de recursos recolectados.
    /// </summary>
    private readonly IResourceCollector _collector;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Forest"/>.
    /// </summary>
    /// <param name="x">Coordenada X en el mapa.</param>
    /// <param name="y">Coordenada Y en el mapa.</param>
    /// <param name="initialWood">Cantidad inicial de madera disponible.</param>
    /// <param name="extractionRate">Tasa de extracción por recolector.</param>
    /// <param name="collectionValue">Valor acumulado por extracción (si aplica).</param>
    /// <param name="ownerId">ID del jugador propietario.</param>
    /// <param name="collector">Instancia que gestiona la lógica de recolección.</param>
    public Forest(int x, int y, int initialWood, int extractionRate, int collectionValue, int ownerId, IResourceCollector collector)
        : base(ownerId, extractionRate, collectionValue, initialWood)
    {
        OwnerId = ownerId;
        _collector = collector;
        Position = (x, y);
        CurrentAmount = initialWood;
    }

    /// <summary>
    /// Extrae recursos del bosque en segun del numero de recolectores.
    /// </summary>
    /// <param name="collectors">Cantidad de recolectores asignados a este bosque.</param>
    /// <returns>Cantidad total de madera recolectada.</returns>
    public int GetResources(int collectors)
    {
        int collected = _collector.CalculateCollected(Wood, ExtractionRate, collectors);
        Wood -= collected;
        return collected;
    }
}