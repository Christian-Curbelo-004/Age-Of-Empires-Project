using Discord;

namespace ClassLibrary1.Bonus;

public abstract class GameStorage
{
    public abstract void Save(string name, GameState state);
    public abstract GameState? Load(string name);
    public abstract List<string> ListSaves();
}