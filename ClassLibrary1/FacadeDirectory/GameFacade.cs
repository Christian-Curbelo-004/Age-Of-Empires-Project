using System;
using CivicCenterNamespace;
using ClassLibrary1.LogicDirectory;
using ClassLibrary1.CivilizationDirectory;
namespace ClassLibrary1
{
    public class GameFacade : IFacade
    {
        public void GenerateMap(PlayerOne playerOne)
        {
        }
        public void GenerateCivicCenter(PlayerOne playerOne)
        {
            playerOne.CivicCenter = new CivicCenter(
                endurence: 100,
                constructiontimeleft: 10,
                name: "Centro Cívico",
                resourceValue: 50
            );
        }
        public void GenerateQuary(PlayerOne playerOne)
        {
        }

        public void GenerateVillagers(PlayerOne playerOne)
        {
        }

        public void TrainSoldiers(PlayerOne playerOne)
        {
        }

        public void InitializePlayer(PlayerOne playerOne)
        {
            playerOne.Food = 100;
            playerOne.Wood = 100;
            GenerateCivicCenter(playerOne);
            GenerateVillagers(playerOne);
        }
    }
}