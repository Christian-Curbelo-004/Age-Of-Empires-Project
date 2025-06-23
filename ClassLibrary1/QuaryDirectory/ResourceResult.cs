namespace ClassLibrary1.QuaryDirectory
{
    public class ResourceResult
    {
        public int Amount { get; set; }
        public string Message { get; set; }

        public ResourceResult(int amount, string message)
        {
            Amount = amount;
            Message = message;
        }
    }
}