using System;
using ClassLibrary1;
using ClassLibrary1.CivilizationDirectory;

namespace ClassLibrary1;

class Program
{
    static void Main(string[] args)
    {
        GameFacade game = new GameFacade();
        PlayerOne playerOne = new PlayerOne("joaco",new Roman());
    }
}

