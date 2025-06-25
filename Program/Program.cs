/*¡using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.QuaryDirectory;
using ClassLibrary1.FacadeDirectory;
using GameModels;
using QuaryBiome;
using ClassLibrary1.LogicDirectory;

namespace ClassLibrary1;

class Program
{
    static void Main()
    {
        GameFacade facade = new GameFacade();
        Civilization civ1 = ElegiUnaCivilizacion();
        GameState state = facade.StartNewGame(civ1);
        GameLogic logic = new GameLogic();

        Player playerOne = state.PlayerOne;
        Player playerTwo = state.PlayerTwo;
        Map map = state.Map;

        // Crear CivicCenters con OwnerId
        int width = map.map.GetLength(0);
        int height = map.map.GetLength(1);

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
        }

        // Generar recursos aleatorios en esquinas
        RecursosEnEsquinas(map, 0, 0, 20, 20, 10);
        RecursosEnEsquinas(map, width - 20, height - 20, 20, 20, 10);

        var print = new PrintMap(map);
        print.DisplayMap();

        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine(
                $"Población: {playerOne.CivicCenter.CurrentVillagers + playerOne.CivicCenter.CurrentSoldiers} / {playerOne.CivicCenter.MaxVillagers + playerOne.CivicCenter.MaxSoldiers}");
            Console.WriteLine("Recursos actuales:");
            Console.WriteLine($"Comida: {playerOne.Resources[GameResourceType.Food]}");
            Console.WriteLine($"Piedra: {playerOne.Resources[GameResourceType.Stone]}");
            Console.WriteLine($"Madera: {playerOne.Resources[GameResourceType.Wood]}");
            Console.WriteLine($"Oro: {playerOne.Resources[GameResourceType.Gold]}");

            Console.WriteLine("Menú principal:");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Elegí una civilización");
            Console.WriteLine("2. Atacar");
            Console.WriteLine("3. Construir");
            Console.WriteLine("4. Recolectar recursos");
            Console.WriteLine("5. Guardar partida");
            Console.WriteLine("6. Mover unidad");
            Console.WriteLine("7. Salir");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    Atacar(map);
                    print.DisplayMap();
                    break;

                case "3":
                    Construir(map, playerOne);
                    print.DisplayMap();
                    break;

                case "4":
                    // Implementar recolección si querés
                    break;

                case "5":
                    Console.WriteLine("Guardando partida...");
                    Console.ReadKey();
                    break;

                case "6":
                    MoverUnidad(map);
                    print.DisplayMap();
                    break;

                case "7":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static Civilization ElegiUnaCivilizacion()
    {
        while (true)
        {
            Console.WriteLine("¡Bienvenido a Age of Empires!");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Elija su civilización:");
            Console.WriteLine("1: Romans");
            Console.WriteLine("2: Vikings");
            Console.WriteLine("3: Templaries");

            string? opcion = Console.ReadLine();

            if (opcion == "1") return new Roman();
            if (opcion == "2") return new Viking();
            if (opcion == "3") return new Templaries();

            Console.WriteLine("Opción inválida. Intente nuevamente.");
        }
    }

    static void Atacar(Map map)
    {
        Console.WriteLine("Selecciona la unidad para atacar:");
        Console.WriteLine("7: Infantery");
        Console.WriteLine("8: Chivarly");
        Console.WriteLine("9: Villagers");

        PrintMap printMap = new PrintMap(map);
        printMap.DisplayMap();
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }

    static void Construir(Map map, Player player)
    {
        Console.WriteLine("Selecciona el edificio para construir:");
        Console.WriteLine("4: Civic Center");
        Console.WriteLine("5: Infantry Center");
        Console.WriteLine("6: Chivalry Center");
        Console.WriteLine("7: Archer Center");
        Console.WriteLine("8: Wood Deposit");
        Console.WriteLine("9: Gold Deposit");
        Console.WriteLine("10: Stone Deposit");
        Console.WriteLine("11: WindMill Deposit");

        string? opcion = Console.ReadLine();

        Console.WriteLine("Ingresá las coordenadas X Y para construir (ej: 10 5):");
        string[] coords = Console.ReadLine()?.Split() ?? Array.Empty<string>();

        if (coords.Length < 2 ||
            !int.TryParse(coords[0], out int x) ||
            !int.TryParse(coords[1], out int y))
        {
            Console.WriteLine("Coordenadas inválidas.");
            Console.ReadKey();
            return;
        }

        if (!map.IsWithinBounds(x, y))
        {
            Console.WriteLine($"Las coordenadas ({x}, {y}) están fuera del rango del mapa.");
            Console.ReadKey();
            return;
        }

        if (map.IsCellOccupied(x, y))
        {
            Console.WriteLine($"La celda en ({x}, {y}) ya está ocupada.");
            Console.ReadKey();
            return;
        }

        IMapEntidad edificio = opcion switch
        {
            "4" => new CivicCenter(50, 30, "Civic Center", player.Id),
            "5" => new InfanteryCenter(40, 25, "Infantry Center", player.Id),
            "6" => new ChivarlyCenter(45, 30, "Chivalry Center", player.Id),
            "7" => new ArcherCenter(40, 25, "Archer Center", player.Id),
            "8" => new WoodDeposit(30, 20, "Wood Deposit", 500, player.Id),
            "9" => new GoldDeposit(30, 20, "Gold Deposit", 500, player.Id),
            "10" => new StoneDeposit(30, 20, "Stone Deposit", 500, player.Id),
            "11" => new WindMill(30, 20, "WindMill Deposit", 500, player.Id),
            _ => null
        };

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

    static void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height, int cantidadrecursos)
    {
        Random random = new Random();
        for (int i = 0; i < cantidadrecursos; i++)
        {
            int x = random.Next(inicialX, inicialX + width);
            int y = random.Next(inicialY, inicialY + height);

            int recurso = random.Next(3);
            IMapEntidad entidad;

            if (recurso == 0)
                entidad = new Forest(5, 0, "Madera", 150);
            else if (recurso == 1)
                entidad = new GoldMine(5, 0, "Gold", 50);
            else
                entidad = new StoneMine(5, 0, "Stone", 75);

            map.PonerEntidad(x, y, entidad);
        }
    }
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
        gameFacade.RecursosEnEsquinas(map, 0, 0, 30, 30, 20);
        gameFacade.RecursosEnEsquinas(map,70,70,30,30,20);
        gameFacade.InitializePlayer(map);
        ShowScreen showScreen = new ShowScreen(map, gameFacade.PlayerOne);
        showScreen.Screen();
    }
}
