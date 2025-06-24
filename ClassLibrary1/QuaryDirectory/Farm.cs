namespace ClassLibrary1.QuaryDirectory
{
    public class Farm : Quary
    {
        public Farm(int extractionRate, int collectionValue, int initialFood)
            : base(extractionRate, collectionValue, initialFood, 300, "Food")
        {
        }
    }
}