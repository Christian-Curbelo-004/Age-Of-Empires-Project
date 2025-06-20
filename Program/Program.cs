using System;
using System.Data;
using ClassLibrary1;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.QuaryDirectory;
using QuaryBiome;

namespace ClassLibrary1.FacadeDirectory;

class Program
{
    static void Main(string[] args)
    {
        GameFacade game = new GameFacade();
        PlayerOne playerOne = new PlayerOne("joaco",new Roman());

        Map map = new Map(100, 100);

        RecursosEnEsquinas(map, 70, 0, 30, 30);
        RecursosEnEsquinas(map, 0, 70, 30, 30);
        
        PrintMap printmap = new PrintMap(map);
        Console.WriteLine(printmap.GetMapAsString());

        static void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height)
        {
            Random random = new Random();
            for (int y = inicialY; y < inicialX + width; y++)
            {
                for (int x = inicialY; x < inicialX + height; x++)
                {
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
                
            }
        }

    }
}

