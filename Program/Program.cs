using System;
using System.Data;
using ClassLibrary1;
using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
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

        RecursosEnEsquinas(map, 70, 0, 30, 30,20);
        RecursosEnEsquinas(map, 0, 70, 30, 30,20);
        
        PrintMap printmap = new PrintMap(map);
        Console.WriteLine(printmap.GetMapAsString());

        static void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height, int cantidadrecursos)
        {
            Random random = new Random();
            for (int i = 0; i < cantidadrecursos ; i++)
            {
                int x = random.Next(inicialX, inicialX + width);
                int y = random.Next(inicialY, inicialY + height);
                
                    int recurso = random.Next(3);
                    IMapEntidad entidad;

                    if (recurso == 0)
                    {
                        entidad = new Forest(collectiontimeleft: 5, collectionvalue: 0, collectiontype: "Madera", wood: 150);
                    }
                    else if (recurso == 1)
                    {
                        entidad = new GoldMine(collectiontimeleft: 5, collectionvalue: 0, collectiontype: "Gold", gold: 50);
                    }
                    else
                    {
                        entidad = new StoneMine(collectiontimeleft: 5, collectionvalue: 0, collectiontype: "Stone", stone: 75);
                    }

                    map.PonerEntidad(x, y, entidad);

            }

            int centrocivX = inicialX + width / 2;
            int centrocivY = inicialY + height / 2;

            CivicCenter civicCenter = new CivicCenter(50,30,"Civic Center");
            map.PonerEntidad(centrocivX,centrocivY,civicCenter);

        }

    }
}

