namespace ClassLibrary1.Bonus;



using System.Text.Json;

public class SaveGame: GameStorage
{
    private readonly string _folder = "Partidas";

    public override void Save(string name, GameState state)
    {
        Directory.CreateDirectory(_folder);
        string path = Path.Combine(_folder, $"{name}.txt");
        string json = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public override GameState? Load(string name)
    {
        string path = Path.Combine(_folder, $"{name}.txt");

        if (!File.Exists(path))
            throw new Exception("Partida no encontrada.");

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<GameState>(json);
    }

    public override List<string> ListSaves()
    {
        if (!Directory.Exists(_folder))
            return new List<string>();

        return Directory.GetFiles(_folder, "*.txt").Select(Path.GetFileNameWithoutExtension).ToList();
    }
}

