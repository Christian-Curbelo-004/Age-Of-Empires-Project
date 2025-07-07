/// <summary>
/// Representa una cantera abstracta que define el comportamiento común de las minas.
/// lógica base para la extraccion de recursos.
/// </summary>
public abstract class Quary
{
    /// <summary>
    /// Id del jugador que esta en esa quary
    /// </summary>
    public int OwnerId { get; set; }

    /// <summary>
    ///  nombre de la cantera.
    /// </summary>
    public string Name { get; set; } = "Quary";

    /// <summary>
    /// Cantidad de recurso extraído por recolector en cada ciclo.
    /// </summary>
    public int ExtractionRate { get; set; }

    /// <summary>
    /// Valor total recolectado por unidad de extracción.
    /// </summary>
    public int CollectionValue { get; set; }

    /// <summary>
    /// Cantidad actual de recursos disponibles en la cantera.
    /// </summary>
    public int CurrentAmount { get; set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Quary"/>.
    /// </summary>
    /// <param name="ownerId">ID del jugador propietario.</param>
    /// <param name="extractionRate">Tasa de extracción por recolector.</param>
    /// <param name="collectionValue">Valor que se acumula por unidad de extracción.</param>
    /// <param name="initialAmount">Cantidad inicial de recurso disponible.</param>
    public Quary(int ownerId, int extractionRate, int collectionValue, int initialAmount)
    {
        OwnerId = ownerId;
        ExtractionRate = extractionRate;
        CollectionValue = collectionValue;
        CurrentAmount = initialAmount;
    }

    /// <summary>
    /// Calcula la cantidad de recursos recolectados segund la cantidad de recolectores.
    /// </summary>
    /// <param name="collectors">Cantidad de recolectores asignados.</param>
    /// <returns>Cantidad total de recurso extraído.</returns>
    public virtual int GetResources(int collectors)
    {
        return ExtractionRate * collectors;
    }
}