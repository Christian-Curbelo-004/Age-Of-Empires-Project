using ClassLibrary1.MapDirectory;
public class VerificarPartidaPerdida
{
    private readonly Map _map;
    private readonly CivicCenterChecker _checker;
    public bool PartidaTerminada { get; private set; }

    public VerificarPartidaPerdida(Map map)
    {
        _map = map;
        _checker = new CivicCenterChecker(_map);
    }

    public void Verificar(int playerOneId, int playerTwoId)
    {
        int ccPlayerOne = _checker.CountCivicCenters(playerOneId);
        int ccPlayerTwo = _checker.CountCivicCenters(playerTwoId);

        if (ccPlayerOne == 0 || ccPlayerTwo == 0)
        {
            PartidaTerminada = true;
        }
    }
}