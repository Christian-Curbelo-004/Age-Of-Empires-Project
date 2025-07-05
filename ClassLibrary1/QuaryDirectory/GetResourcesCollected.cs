namespace ClassLibrary1.QuaryDirectory;

public static class GetResourcesCollected
{
    public static int ResourceCollected(int resourceAmount, int extractionRate, int collectors)
    {
        int amount = extractionRate * collectors; // para ver la cantidad que se puede recolectar con toda la cantidad de recolectores que van
        int collected = Math.Min(resourceAmount, amount);//para ver cuato se recolecta con lo que tengo en el deposito y lo que hay
        return collected;
    }
}