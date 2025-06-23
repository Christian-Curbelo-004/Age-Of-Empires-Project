using ClassLibrary1.BuildingsDirectory;
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
        static Civilization ElegiUnaCivilizacion()
        {
            {
                while (true)
                {
                    Console.WriteLine("1: Romans");
                    Console.WriteLine("2: Vikings");
                    Console.WriteLine("3: Templaries");

                    string? opcion = Console.ReadLine();

                    Civilization civ = null;
                    if (opcion == "1")
                        civ = new Roman();
                    else if (opcion == "2")
                        civ = new Viking();
                    else if (opcion == "3")
                        civ = new Templaries();

                    return civ;
                }
            }
        }
        Player playerOne = state.PlayerOne;
        Map map = state.Map;

        bool salir = false;                 // menu

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a Age of Empires");
            Console.WriteLine($"Ingresa tu nombre {playerOne.Name} ");
            Console.WriteLine($"Población: {playerOne.CivicCenter.CurrentVillagers + playerOne.CivicCenter.CurrentSoldiers} / {playerOne.CivicCenter.MaxVillagers + playerOne.CivicCenter.MaxSoldiers}");
            Console.WriteLine($"Recursos actuales: ");
            Console.WriteLine($"Comida: {playerOne.Resources[GameResourceType.Food]}");
            Console.WriteLine($"Piedra: {playerOne.Resources[GameResourceType.Stone]}");
            Console.WriteLine($"Madera: {playerOne.Resources[GameResourceType.Wood]}");
            Console.WriteLine($"Oro: {playerOne.Resources[GameResourceType.Gold]}");
            
            Console.WriteLine("Menú principal: ");
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
                    //Civilization civilization = ElegiUnaCivilizacion();
                    //playerOne = new Player(playerOne.Name, civilization);
                    //Console.WriteLine($"Elegiste la civilización: {civilization.GetType().Name}");
                    
                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    Atacar(map);
                    break;


                case "3":
                    Construir(map,playerOne);
                    break;


                case "4":
                    Console.WriteLine("Recolectando con lógica:");
                    logic.VillagersLogic(playerOne);
                    Console.WriteLine("Aldeanos recolectaron recursos.");
                    Console.ReadKey();
                    break;

                case "5":
                    MoverUnidad(map);
                    break;
                case "6":
                    salir = true;
                    break;
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

            static void MoverUnidad(Map map)
            {
                Console.WriteLine("De que coordenadas queres mover algo?:");
                string[] origenCoords = Console.ReadLine()?.Split() ?? Array.Empty<string>();

                Console.WriteLine("Para donde quers mover?:");
                string[] destinoCoords = Console.ReadLine()?.Split() ?? Array.Empty<string>();

                if (origenCoords.Length < 2 || destinoCoords.Length < 2 ||
                    !int.TryParse(origenCoords[0], out int origenX) ||
                    !int.TryParse(origenCoords[1], out int origenY) ||
                    !int.TryParse(destinoCoords[0], out int destinoX) ||
                    !int.TryParse(destinoCoords[1], out int destinoY))
                {
                    Console.WriteLine("Coordenadas mal colocadas");
                    Console.ReadKey();
                    return;
                }

                bool moverse = map.MoverEntidad(origenX, origenY, destinoX, destinoY);
                if (moverse)
                {
                    Console.WriteLine("Se movio la entidad de coordenada");
                }
                else
                {
                    Console.WriteLine("No se pudo mover");
                }

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
                        civicCenter.GetConstructionCost();
                        var cost = civicCenter.ConstructionCost;
                        if (!player.HasResources(cost))
                        {
                            Console.WriteLine("No tenes Recursos suficientes para construir esto");
                            Console.ReadKey();
                            return;
                        }
                        player.SpendResources(cost);
                        map.PonerEntidad(50, 30, civicCenter);
                        break;

                    case "5":
                        infanteryCenter.GetConstructionCost();
                        var cost5 = infanteryCenter.ConstructionCost;
                        if (!player.HasResources(cost5))
                        {
                            Console.WriteLine("No tenés recursos suficientes para construir esto.");
                            Console.ReadKey();
                            return;
                        }
                        player.SpendResources(cost5);
                        map.PonerEntidad(123, 30, infanteryCenter);
                        break;

                    case "6":
                        chivarlyCenter.GetConstructionCost();
                        var cost6 = chivarlyCenter.ConstructionCost;
                        if (!player.HasResources(cost6))
                        {
                            Console.WriteLine("No tenés recursos suficientes para construir esto.");
                            Console.ReadKey();
                            return;
                        }
                        player.SpendResources(cost6);
                        map.PonerEntidad(200, 20, chivarlyCenter);
                        break;

                    case "7":
                        archerCenter.GetConstructionCost();
                        var cost7 = archerCenter.ConstructionCost;
                        if (!player.HasResources(cost7))
                        {
                            Console.WriteLine("No tenés recursos suficientes para construir esto.");
                            Console.ReadKey();
                            return;
                        }
                        player.SpendResources(cost7);
                        map.PonerEntidad(150, 10, archerCenter);
                        break;

                    case "8":
                        woodDeposit.GetConstructionCost();
                        var cost8 = woodDeposit.ConstructionCost;
                        if (!player.HasResources(cost8))
                        {
                            Console.WriteLine("No tenés recursos suficientes para construir esto.");
                            Console.ReadKey();
                            return;
                        }
                        player.SpendResources(cost8);
                        map.PonerEntidad(60, 20, woodDeposit);
                        break;

                    case "9":
                        goldDeposit.GetConstructionCost();
                        var cost9 = goldDeposit.ConstructionCost;
                        if (!player.HasResources(cost9))
                        {
                            Console.WriteLine("No tenés recursos suficientes para construir esto.");
                            Console.ReadKey();
                            return;
                        }
                        player.SpendResources(cost9);
                        map.PonerEntidad(210, 32, goldDeposit);
                        break;

                    case "10":
                        stoneDeposit.GetConstructionCost();
                        var cost10 = stoneDeposit.ConstructionCost;
                        if (!player.HasResources(cost10))
                        {
                            Console.WriteLine("No tenés recursos suficientes para construir esto.");
                            Console.ReadKey();
                            return;
                        }
                        player.SpendResources(cost10);
                        map.PonerEntidad(20, 30, stoneDeposit);
                        break;

                    case "11":
                        windMill.GetConstructionCost();
                        var cost11 = windMill.ConstructionCost;
                        if (!player.HasResources(cost11))
                        {
                            Console.WriteLine("No tenés recursos suficientes para construir esto.");
                            Console.ReadKey();
                            return;
                        }
                        player.SpendResources(cost11);
                        map.PonerEntidad(12, 30, windMill);
                        break;
                    case "12":
                        var houseV = new HomeVillagers(20, 10, "Casa de aldeanos");
                        map.PonerEntidad(17,34,houseV);
                        player.CivicCenter.AddHomeVillagersCapacity();
                        Console.WriteLine("Limite de aldeanos aumentado");
                        break;
                    case "13":
                        var houseS = new HomeSoldiers(20, 10, "Casa de soldados");
                        map.PonerEntidad(18,23,houseS);
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
                            entidad = new Forest(ExtractionRate: 5, collectionvalue: 0,
                                collectiontype: "Madera",
                                wood: 150);
                        }
                        else if (recurso == 1)
                        {
                            entidad = new GoldMine(collectiontimeleft: 5, collectionvalue: 0,
                                collectiontype: "Gold",
                                gold: 50);
                        }
                        else
                        {
                            entidad = new StoneMine(collectiontimeleft: 5, collectionvalue: 0,
                                collectiontype: "Stone",
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

