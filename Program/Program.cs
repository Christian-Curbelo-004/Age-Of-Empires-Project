/*
        Civilization civ1 = ElegiUnaCivilizacion();
        GameState state = facade.StartNewGame(civ1);
        GameLogic logic = new GameLogic();


        var civic1 = new CivicCenter(100, 10, "Civic Center", playerOne.Id);
        map.map[1, 1].Entity = civic1;
        map.map[1, 1].EntityType = "CivicCenter";
        map.map[1, 1].IsOccupied = true;
        playerOne.CivicCenter = civic1;

        var civic2 = new CivicCenter(100, 10, "Civic Center", playerTwo.Id);
        map.map[width - 2, height - 2].Entity = civic2;
        map.map[width - 2, height - 2].EntityType = "CivicCenter";
        map.map[width - 2, height - 2].IsOccupied = true;
        playerTwo.CivicCenter = civic2;

        // Crear aldeanos alrededor de los CivicCenters (jugador 1 y 2) ...
        var posicionesAldeanos1 = new (int x, int y)[] { (2, 1), (1, 2), (2, 2) };
        foreach (var (x, y) in posicionesAldeanos1)
        {
            var villager = new Villagers(100, 5, playerOne.Id);
            map.map[x, y].Entity = villager;
            map.map[x, y].EntityType = "Villagers";
            map.map[x, y].IsOccupied = true;
            playerOne.AddVillagers(villager);
        }

        var posicionesAldeanos2 = new (int x, int y)[]
            { (width - 3, height - 2), (width - 2, height - 3), (width - 3, height - 3) };
        foreach (var (x, y) in posicionesAldeanos2)
        {
            var villager = new Villagers(100, 5, playerTwo.Id);
            map.map[x, y].Entity = villager;
            map.map[x, y].EntityType = "Villagers";
            map.map[x, y].IsOccupied = true;
            playerTwo.AddVillagers(villager);
    
    static Civilization ElegiUnaCivilizacion()

        if (edificio == null)
        {
            Console.WriteLine("Opción de edificio inválida.");
            Console.ReadKey();
            return;
        }

        map.PonerEntidad(x, y, edificio);
        Console.WriteLine($"{edificio.Name} construido en ({x}, {y}).");
        Console.ReadKey();
    }

    static void MoverUnidad(Map map)
    {
        Console.WriteLine("De qué coordenadas quieres mover algo?");
        string[] origenCoords = Console.ReadLine()?.Split() ?? Array.Empty<string>();

        Console.WriteLine("Hacia dónde quieres mover?");
        string[] destinoCoords = Console.ReadLine()?.Split() ?? Array.Empty<string>();

        if (origenCoords.Length < 2 || destinoCoords.Length < 2 ||
            !int.TryParse(origenCoords[0], out int origenX) ||
            !int.TryParse(origenCoords[1], out int origenY) ||
            !int.TryParse(destinoCoords[0], out int destinoX) ||
            !int.TryParse(destinoCoords[1], out int destinoY))
        {
            Console.WriteLine("Coordenadas mal colocadas.");
            Console.ReadKey();
            return;
        }

        bool moverse = map.MoverEntidad(origenX, origenY, destinoX, destinoY);
        Console.WriteLine(moverse ? "Se movió la entidad." : "No se pudo mover.");
        Console.ReadKey();
    }
*/
using ClassLibrary1;
using ClassLibrary1.MapDirectory;
using ClassLibrary1.FacadeDirectory;


class Program
{
    static void Main(string[] args)
    {
        GameFacade gameFacade = new GameFacade();
        Map map = gameFacade.GenerateMap();
        gameFacade.RecursosEnEsquinas(map, 0, 0, 50, 50,70 );
        gameFacade.RecursosEnEsquinas(map,50,50,50,50,70);
        gameFacade.InitializePlayer(map);
        ShowScreen showScreen = new ShowScreen(map, gameFacade.PlayerOne);
        showScreen.Screen();
    }
}
