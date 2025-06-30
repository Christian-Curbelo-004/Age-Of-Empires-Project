using ClassLibrary1.BuildingsDirectory;
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

        int actualhealth = _playerOne.CivicCenter.ActualHealth;
        if ( actualhealth > 0 && actualhealth <= CivicCenter.MaxHealth * 0.10) // esto es para que si la vida actual del centro civico llega a ser igual al 10 % o menos del centro civico, te avise que estas en riesgo de perder
        {
            Console.WriteLine("Tenes poca vida en el centro civico, vas a perder crack :)");
        }
        
        string continueplaying = "seguis jugando";
        string message = "Perdiste";
        int health = _playerOne.CivicCenter.ActualHealth;
        if (health < 0)
        {
            return message;
        }
        return continueplaying;
    }

    public List<string> GetInfoResources()
    {
        List<string> Resources = new List<string>();
        foreach (Deposit deposit in _map.GetEntities<Deposit>())
        {
            string resourceAmount =
                $"{deposit.GetType().Name} tiene {deposit.ActualResources()} de {deposit.MaxCapacity} ";
            Resources.Add(resourceAmount);
        }

        return Resources;
    }

    public void ShowRecolectionResourceMuf(GameFacade gameFacade) //para usar la logica del gamefacade que te guarda en un diccionario la tasa de recoleccion que recolectas por vez, y aca te lo muestre 
    {
        var ResourceMug = gameFacade.TasaRecoleccionRecurso(); // ResourceMug == Taza de recolección
        foreach (var recolect in ResourceMug)
        {
            Console.WriteLine($"{recolect.Key} : {recolect.Value}");
        }
        
    }
    
}   
