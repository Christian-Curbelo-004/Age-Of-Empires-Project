using ClassLibrary1.CommandDirectory;
using CommandDirectory;

public class CommandProcessor
{
    private readonly Dictionary<string, IGameCommand> _commands;

    public CommandProcessor(Dictionary<string, IGameCommand> commands)
    {
        _commands = commands;
    }

    public async Task<string> ProcessCommand(string input, Player currentPlayer)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "El comando está vacío.";

        var parts = input.Split('+');
        if (parts.Length < 3)
            return "El comando debe tener el formato: verbo+entidad+parametros.";

        string verb = parts[0].ToLower();
        string entityType = parts[1];
        string parameters = string.Join('+', parts.Skip(2)); 

        if (!_commands.TryGetValue(verb, out var command))
            return $"Comando no reconocido: '{verb}'.";

        try
        {
            if (command is IPlayerCommand playerCommand)
                return await playerCommand.ExecuteAsync(entityType, parameters, currentPlayer);
            else
                return "Este comando no admite jugadores. Implementalo como IPlayerCommand.";
        }
        catch (Exception ex)
        {
            return $"Error al ejecutar el comando: {ex.Message}";
        }
    }
}