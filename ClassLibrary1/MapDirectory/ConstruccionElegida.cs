using ClassLibrary1.CivilizationDirectory;

namespace ClassLibrary1.MapDirectory;

public class ConstruccionElegida
{
    private Map _map;

    public ConstruccionElegida(Map map)
    {
        _map = map;
    }

    public void Construir(int x,int y, IMapEntidad entitytype)
    {
        if (_map.IsCellOccupied(x, y))
        {
            throw new InvalidOperationException("$esta ocupada"); //por si ya esta ocupada cuando pasas la cordenada
        }
        _map.PonerEntidad(x,y,entitytype);
    }
}
