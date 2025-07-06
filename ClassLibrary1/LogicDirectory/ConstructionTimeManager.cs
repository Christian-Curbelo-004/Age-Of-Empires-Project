using ClassLibrary1.BuildingsDirectory;

namespace ClassLibrary1.LogicDirectory;

public class ConstructionTimeManager
{
    public static async Task<T> BuildAsync<T>(T building, int constructiontimeleft) where T : Buildings
    {
        await Task.Delay(constructiontimeleft);
        return building;
    }
}