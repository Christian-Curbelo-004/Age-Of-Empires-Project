// using System;
// using System.Data;
// using ClassLibrary1;
// using System.IO;

using System.Security.AccessControl;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.DepositDirectory;
using ClassLibrary1.QuaryDirectory;
using QuaryBiome;
using ClassLibrary1.FacadeDirectory;

namespace ClassLibrary1;

class Program
{
    static void Main(string[] args)
    {
        GameFacade game = new GameFacade();
        PlayerOne playerOne = new PlayerOne("joaco",new Roman());

        Map map = new Map(100, 100);
        
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a Age of Empires");
            Console.WriteLine($"Ingresa tu nombre {playerOne.Name} ");

            Console.WriteLine("Menú principal: ");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Seleccioná una opción: ");
            Console.WriteLine("1. Elegí una civilizacón");
            Console.WriteLine("2: Construir: ");
            Console.WriteLine("3: Atacar: ");
            Console.WriteLine("4 Guardar partida: ");
            Console.WriteLine("5: Salir: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ElegiUnaCivilizacion();
                    salir = true;
                    break;

                case "2":
                    Construir();
                    salir = true;
                    break;
                case "3":
                    Atacar();
                    break;
                case "4":
                    GuardarPartida();
                    salir = true;
                    break;
                case "5":
                    salir = true;
                    break;
            }

            static void ElegiUnaCivilizacion()
            {
                Console.WriteLine("1: Romans");
                Console.WriteLine("2: Vikings");
                Console.WriteLine("3: Paladins");

                string seleccion = Console.ReadLine();

                // Roman roman = new Roman();
                // Viking viking = new Viking();
                // Paladin paladin = new Paladin();

            }

            static void Construir()
            {
                Console.WriteLine("4: Civic Center");
                Console.WriteLine("5: Infantery Center");
                Console.WriteLine("6: Chivarly Center");
                Console.WriteLine("7: Wood Deposit ");
                Console.WriteLine("8: Gold Deposit ");
                Console.WriteLine("9: Stone Deposit ");

                string seleccion = Console.ReadLine();

                CivicCenter civicCenter = new CivicCenter(50, 30, "Civic Center");
                InfanteryCenter infanteryCenter = new InfanteryCenter(50, 30, "Infantery Center");
                ChivarlyCenter chivarlyCenter = new ChivarlyCenter(50, 30, "Chivarly Center");

                WoodDeposit woodDeposit = new WoodDeposit(123, 20, "Wood Deposit ", 123);
                GoldDeposit goldDeposit = new GoldDeposit(200, 50, "Gold Deposit ", 23);
                StoneDeposit stoneDeposit = new StoneDeposit(170, 30, "Stone Deposit ", 176);
                

            }

            static void Atacar()
            {
                Console.WriteLine("7: Infantery");
                Console.WriteLine("8: Chivarly");
                Console.WriteLine("9: Villagers");
            }

            static void GuardarPartida()
            {
                // con un txt
            }

            RecursosEnEsquinas(map, 70, 0, 30, 30, 20);
            RecursosEnEsquinas(map, 0, 70, 30, 30, 20);

            PrintMap printmap = new PrintMap(map);
            Console.WriteLine(printmap.GetMapAsString());

            static void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height,
                int cantidadrecursos)
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
