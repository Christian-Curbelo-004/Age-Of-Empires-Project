using ClassLibrary1.MapDirectory;
using CreateBuildings;

namespace ClassLibrary1.BuildingsDirectory;
// Creo que hay que sacarla
public class Constructor
{
    public async Task BuildEstructura(Buildings buildings, Map map, int x, int y, Player player)
    {
        int timeleft = buildings.ConstructionTime;
        while (timeleft > 0)
        {
            await Task.Delay(1000); //para poder poner los segundos en los que se construye
            timeleft--;
        }

        buildings.IsConstructed = true; //para cambiar en el mapa para cuando esta construido ya se ocupe el espacio
        buildings.Position = (x, y); 
        buildings.OwnerId = player.Id; //pra que jugador es que se esta creando la estructura
        map.PlaceEntity(buildings, x, y); //para agregarlo en las coordenadas del mapa
    }
}