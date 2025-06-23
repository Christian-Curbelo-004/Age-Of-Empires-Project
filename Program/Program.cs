using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.QuaryDirectory;
using ClassLibrary1.FacadeDirectory;
using QuaryBiome;


namespace ClassLibrary1;

class Program
{
    static void Main() // string[] args (borrado)
    {
        GameFacade facade = new GameFacade();
        GameState state = facade.StartNewGame();

        Player playerOne = state.PlayerOne;
        Map map = state.Map;

        bool salir = false; // menu

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a Age of Empires");
            Console.WriteLine($"Ingresa tu nombre {playerOne.Name} ");

            Console.WriteLine("Menú principal: ");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Seleccioná una opción: ");
            Console.WriteLine("1. Elegí una civilizacón");
            Console.WriteLine("2: Atacar: ");
            Console.WriteLine("3: Construir: ");
            Console.WriteLine("4 Guardar partida: ");
            Console.WriteLine("5: Salir: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Civilization civilization = ElegiUnaCivilizacion(map);
                    playerOne = new Player(playerOne.Name, civilization);
                    Console.WriteLine($"Elegiste la civilización: {civilization.GetType().Name}");

                    PrintMap printMap = new PrintMap(map);
                    printMap.DisplayMap();

                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    Atacar(map);
                    break;


                case "3":
                    Construir(map, playerOne);
                    break;


                case "4":
                //   GuardarPartida();
                //   break;

                case "5":
                    salir = true;
                    break;
            }

            static Civilization ElegiUnaCivilizacion(Map map) // metodos
            {
                while (true)
                {
                    Console.WriteLine("1: Romans");
                    Console.WriteLine("2: Vikings");
                    Console.WriteLine("3: Templaries");

                    string? opcion = Console.ReadLine();

                    if (opcion == "1") return new Roman();
                    if (opcion == "2") return new Viking();
                    if (opcion == "3") return new Templaries();

                    PrintMap printmap = new PrintMap(map);
                    printmap.DisplayMap();

                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();

                }
            }

            static void Atacar(Map map)
            {
                Console.WriteLine("7: Infantery");
                Console.WriteLine("8: Chivarly");
                Console.WriteLine("9: Villagers");

                PrintMap printMap = new PrintMap(map);
                printMap.DisplayMap();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }

            static void Construir(Map map, Player player)
            {
                Console.WriteLine("4: Civic Center");
                Console.WriteLine("5: Infantery Center");
                Console.WriteLine("6: Chivarly Center");
                Console.WriteLine("7: Archer Center: ");
                Console.WriteLine("8: Wood Deposit ");
                Console.WriteLine("9: Gold Deposit ");
                Console.WriteLine("10: Stone Deposit ");
                Console.WriteLine("11: WindMill Deposit ");

                string opcion = Console.ReadLine() ?? "";

                
                InfanteryCenter infanteryCenter = new InfanteryCenter(50, 30, "Infantery Center");
                ChivarlyCenter chivarlyCenter = new ChivarlyCenter(50, 30, "Chivarly Center");
                ArcherCenter archerCenter = new ArcherCenter(50, 30, "Archer Center");

                WoodDeposit woodDeposit = new WoodDeposit(123, 20, "Wood Deposit ", 123);
                GoldDeposit goldDeposit = new GoldDeposit(200, 50, "Gold Deposit ", 23);
                StoneDeposit stoneDeposit = new StoneDeposit(170, 30, "Stone Deposit ", 176);
                WindMill windMill = new WindMill(123, 20, "Wind Mill", 123);

                switch (opcion)
                {
                    case "4":
                        CivicCenter civicCenter = new CivicCenter(50, 30, "Civic Center");
                        map.PonerEntidad(50, 30, civicCenter);
                        break;

                    case "5":
                        map.PonerEntidad(123, 30, infanteryCenter);
                        break;

                    case "6":
                        map.PonerEntidad(200, 20, chivarlyCenter);
                        break;

                    case "7":
                        map.PonerEntidad(150, 10, archerCenter);
                        break;

                    case "8":
                        map.PonerEntidad(60, 20, woodDeposit);
                        break;

                    case "9":
                        map.PonerEntidad(210, 32, goldDeposit);
                        break;

                    case "10":
                        map.PonerEntidad(20, 30, stoneDeposit);
                        break;

                    case "11":
                        map.PonerEntidad(12, 30, windMill);
                        break;
                    case "12":
                        
                        var houseV = new HomeVillagers(20, 10, "Casa de aldeanos");
                        map.PonerEntidad(17, 34, houseV);
                        player.CivicCenter.AddHomeVillagersCapacity();
                        Console.WriteLine("Limite de aldeanos aumentado");
                        break;
                    case "13":
                        var houseS = new HomeSoldiers(20, 10, "Casa de soldados");
                        map.PonerEntidad(18, 23, houseS);
                        player.CivicCenter.AddHomeSoldiersCapacity();
                        Console.WriteLine("Limite de soldados aumentado");
                        break;
                    case "14":
                        if (player.CivicCenter.CanCreateVillagers())
                        {
                            var villager = player.CivicCenter.CreateVillagers();
                            player.AddVillagers(villager);
                            Console.WriteLine("Aldeano creado");
                        }
                        else
                        {
                            Console.WriteLine("Limite de aldeanos alcanzado");
                        }
                        break;
                }
            }

            {
                RecursosEnEsquinas(map, 70, 0, 30, 30, 20);
                RecursosEnEsquinas(map, 0, 70, 30, 30, 20);

                PrintMap printmap = new PrintMap(map); // muestra el mapa desp de elegir algun edificio para construir
                printmap.DisplayMap();

                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            }

            static void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height, int cantidadrecursos) // recursos
            {
                Random random = new Random();
                for (int i = 0; i < cantidadrecursos; i++)
                {
                    int x = random.Next(inicialX, inicialX + width);
                    int y = random.Next(inicialY, inicialY + height);

                    int recurso = random.Next(3);
                    IMapEntidad entidad;

                    if (recurso == 0)
                    {
                        entidad = new Forest(collectiontimeleft: 5, collectionvalue: 0, collectiontype: "Madera",
                            wood: 150);
                    }
                    else if (recurso == 1)
                    {
                        entidad = new GoldMine(collectiontimeleft: 5, collectionvalue: 0, collectiontype: "Gold",
                            gold: 50);
                    }
                    else
                    {
                        entidad = new StoneMine(collectiontimeleft: 5, collectionvalue: 0, collectiontype: "Stone",
                            stone: 75);
                    }

                    map.PonerEntidad(x, y, entidad);
                }

                int centrocivX = inicialX + width / 2;
                int centrocivY = inicialY + height / 2;

                CivicCenter civicCenter = new CivicCenter(50, 30, "Civic Center");
                map.PonerEntidad(centrocivX, centrocivY, civicCenter);
            }
        }
    }
}





