using System;
using System.Data;
using ClassLibrary1;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.QuaryDirectory;
using QuaryBiome;

namespace ClassLibrary1;

class Program
{
    static void Main(string[] args)
    {
        GameFacade game = new GameFacade();
        PlayerOne playerOne = new PlayerOne("joaco",new Roman());

        Map map = new Map(100, 100);

        RecursosEnEsquinas(map, 70, 0, 30, 30);
        RecursosEnEsquinas(map, 0, 70, 30, 30);

        static void RecursosEnEsquinas(Map map, int inicialX, int inicialY, int width, int height)
        {
            Random random = new Random();
            for (int x = inicialX; x < inicialX + width; x++)
            {
                for (int y = inicialY; y < inicialY + height; y++)
                {
                    int recurso = random.Next(3);
                    IMapEntidad entidad;

                    if (recurso == 0)
                    {
                        entidad = new Forest(5, 0,"Madera");
                    }
                    else if (recurso == 1)
                    {
                        entidad = new GoldMine(5, 0, "Gold");
                        
                    }
                    else
                    {
                        entidad = new StoneMine(5, 0, "Stone");
                    }

                    map.PonerEntidad(x, y, entidad);

                }
                
            }
        }

    }
}

