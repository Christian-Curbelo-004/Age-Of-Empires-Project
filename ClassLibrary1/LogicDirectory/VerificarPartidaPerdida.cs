using ClassLibrary1.FacadeDirectory;

namespace ClassLibrary1.LogicDirectory;

public class VerificarPartidaPerdida
{
    private readonly GameFacade _gameFacade;
    private readonly Map _map;
    public bool PartidaTerminada { get; set; }

    public VerificarPartidaPerdida(GameFacade gameFacade, Map map)
    {
        _gameFacade = gameFacade;
        _map = map;
        PartidaTerminada = false;
    }

    public bool TieneCivicCenter(Player player)
    {
        foreach (var edificio in player.Buildings)
        {
            if (edificio.GetType().Name == "CivicCenter")
            {
                return true;
            }
        }

        return false;
    }

    public void Verificar()
    {
        bool playeroneTieneCC = TieneCivicCenter(_gameFacade.PlayerOne);
        bool playertwoTieneCC = TieneCivicCenter(_gameFacade.PlayerTwo);

        if (!playeroneTieneCC)
        {
            PartidaTerminada = true;
        }
        else if (!playertwoTieneCC)
        {
            PartidaTerminada = true;
        }
    }
}