namespace ClassLibrary1.LogicDirectory;

public class Menu
{
    public string MenuScreen()
    {
         string MenuMessage ="1. Crear Jugador      Ingresar = (Ingresar NombreJugador Id)" +
                             "2. Elegir Civilización Ingersar = (CrearCivilización Civilización Id)" +
                             "3. Construir           Ingresar = (Construir Unidad Coordenadas<x y> )" +
                             "4. Recolectar          Ingresar = (Recolectar Cantero CantidadAldeanos)" +
                             "5. Crear Aldeanos      Ingresar = (Crear  Aldeanos CantidadAldeanos)" +
                             "6. Crear Soldados      Ingresar = (Crear Soldados CantidadSoldados) " +
                             "7. Atacar              Ingresar = (Atacar )      " +
                             "8. Comandos            Ingresar = (Pedir Comandos NombreJugador)" +
                             "9. Construcciones      Ingresar = (Pedir Opciones CreacionConstruccion)";
         return MenuMessage;
    }
}