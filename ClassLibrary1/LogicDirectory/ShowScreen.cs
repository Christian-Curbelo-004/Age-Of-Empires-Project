using ClassLibrary1.DepositDirectory;
using ClassLibrary1.FacadeDirectory;
using ClassLibrary1.MapDirectory;
namespace ClassLibrary1;

public class ShowScreen
{
    private readonly Map _map;
    private readonly Player _playerOne;
    
    
    public ShowScreen(Map map, Player playerOne)
        {
        _map = map;
        _playerOne = playerOne;
        }

    public string Screen()
    {
        Console.Clear();
        PrintMap printMap = new PrintMap(_map);
        printMap.DisplayMap();
        Console.WriteLine($"Poblacion del juego: {_playerOne.CurrentPoblacion}");
        
        string seguisjugando = "seguis jugando";
        string message = "Perdiste";
        int health = _playerOne.CivicCenter.ActualHealth;
        if (health < 0)
        {
            return message;
        }
        return seguisjugando;
    }

    public List<string> GetInfoResources()
    {
        List<string> Resources = new List<string>();
        foreach (Deposit deposit in _map.GetEntities<Deposit>())
        {
            string recursocantidad =
                $"{deposit.GetType().Name} tiene {deposit.ActualResources()} de {deposit.MaxCapacity} ";
            Resources.Add(recursocantidad);
        }

        return Resources;
    }

    public void ShowTasaRecoleccionRecurso(GameFacade gameFacade) //para usar la logica del gamefacade que te guarda en un diccionario la tasa de recoleccion que recolectas por vez, y aca te lo muestre 
    {
        var tasarecurso = gameFacade.TasaRecoleccionRecurso();
        foreach (var recolectado in tasarecurso)
        {
            Console.WriteLine($"{recolectado.Key} : {recolectado.Value}");
        }
        
    }
    
}   
