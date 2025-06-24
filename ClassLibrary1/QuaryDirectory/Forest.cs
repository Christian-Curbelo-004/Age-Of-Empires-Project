namespace ClassLibrary1.QuaryDirectory
{
    public class Forest : Quary
    {
        public Forest(int extractionRate, int collectionValue, int initialWood)
            : base(extractionRate, collectionValue, initialWood, 300, "Wood")
        {
        }
    }
}