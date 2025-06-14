namespace ClassLibrary1.QuaryDirectory;

public class GoldMine : Quary
{
    public GoldMine(int collectionspeed, int collectionvalue)
            : base(collectionspeed, collectionvalue)
        {
        }

        public int Gold { get; set; }

        public void GetResources(int amount)
        {
            Gold = amount;
            Console.WriteLine(CollectionSpeed);
            Console.WriteLine(CollectionValue);
            Console.WriteLine($"Se recolectó {Gold} de oro");
        }
}
