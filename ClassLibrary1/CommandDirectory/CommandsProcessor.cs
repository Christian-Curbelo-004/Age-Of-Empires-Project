using CommandDirectory;
public class CommandProcessor
{
    private readonly Dictionary<string, IGameCommand> _commands;

    public CommandProcessor(Dictionary<string, IGameCommand> commands)
    {
        _commands = commands;
    }

    public async Task<string> ProcessCommand(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "El comando está vacío.";

        var parts = input.Split('+');
        if (parts.Length < 3)
            return "El comando debe tener el formato: verbo+entidad+parametros.";
 
        string verb = parts[0].ToLower();
        string entityType = parts[1];
        string destination = parts[2];

        if (!_commands.TryGetValue(verb, out var command))
            return $"Comando no reconocido: '{verb}'.";

        try
        {
            string result = await command.ExecuteAsync(entityType, destination);
            return result;
        }
        catch (Exception ex)
        {
            return $"Error al ejecutar el comando: {ex.Message}";
        }
    }
}