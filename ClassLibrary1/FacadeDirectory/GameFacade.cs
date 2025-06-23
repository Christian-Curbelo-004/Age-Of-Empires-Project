using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;


namespace ClassLibrary1.FacadeDirectory 
{
    public class GameFacade : IFacade
    {
        public Map GenerateMap()
        {
            Map randomMap = new Map(100, 100);
            return randomMap;
        }

        public GameState StartNewGame()
        {
            var state = new GameState();

            state.Map = GenerateMap();
            state.PlayerOne = new Player("Joaco", new Roman());
            state.PlayerTwo = new Player("Cpu", new Templaries());
                    
            state.Map.PlayerOne = state.PlayerOne;
        //    state.Map.PlayerTwo = state.PlayerTwo;
            InitializePlayer(state.Map);
            return state;
        }
        public void GenerateCivicCenter(Map map)
        {
            map.PlayerOne.CivicCenter = new CivicCenter(
                endurence: 100,
                constructiontimeleft: 10,
                name: "Centro Cívico"
            );
       
        }
        public void GenerateQuary(Map map)
        {
            Random random = new Random();
            
            Quary stoneQuary = new Quary(
                collectiontimeleft: random.Next(5, 10),
                collectionValue: 0,
                collectionType: "Stone"
            );
            map.PlayerOne.AddQuary(stoneQuary);
        //    map.PlayerTwo.AddQuary(StoneQuary);
            
            Quary goldQuary = new Quary(
                collectiontimeleft: random.Next(7, 15),
                collectionValue: 0,
                collectionType: "Gold"
            );
           map.PlayerOne.AddQuary(goldQuary);
          // map.PlayerTwo.AddQuary(GoldQuary);
            
            Quary woodQuary = new Quary(
                collectiontimeleft: random.Next(4, 9),
                collectionValue: 0,
                collectionType: "Wood"
            );
           map.PlayerOne.AddQuary(woodQuary);
         //  map.PlayerTwo.AddQuary(WoodQuary);
        }
        public void GenerateVillagers(Map map)
        {
            for (int a = 0; a < 3; a++)
            {
                var villager1 = new Villagers(100, 10);
                var villager2 = new Villagers(100, 10);
                map.PlayerOne.AddVillagers(villager1);
                map.PlayerTwo.AddVillagers(villager2);
            }
        }
        public void TrainSoldiers(Map map)
        {
            for (int s = 0; s < 3; s++)
            {
                Archer archer = new Archer();
                Paladin paladin = new Paladin();
                Raider raider = new Raider();
                Centuries centuries = new Centuries();
                Chivarly chevarly = new Chivarly();
                
                map.PlayerOne.AddSoldier(archer);
                map.PlayerOne.AddSoldier(paladin);
                map.PlayerOne.AddSoldier(raider);
                map.PlayerOne.AddSoldier(centuries);
                map.PlayerOne.AddSoldier(chevarly);
                
                map.PlayerTwo.AddSoldier(archer);
                map.PlayerTwo.AddSoldier(paladin);
                map.PlayerTwo.AddSoldier(raider);
                map.PlayerTwo.AddSoldier(centuries);
                map.PlayerTwo.AddSoldier(chevarly);
                
            }
        }

        public void InitializePlayer(Map map)
        {
            map.PlayerOne.Food = 100;
            map.PlayerOne.Wood = 100;
            map.PlayerTwo.Food = 100;
            map.PlayerTwo.Wood = 100;
            GenerateCivicCenter(map);
            GenerateVillagers(map);
            TrainSoldiers(map);
        }
    }
}