using CommandDirectory;
public class CommandProcessor
{
    private readonly Dictionary<string, ICommand> _commands;

    public CommandProcessor(Dictionary<string, ICommand> commands)
    {
        _commands = commands;
    }

    public async Task ProcessCommand(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("El comando está vacío.");
            return;
        }

        var parts = input.Split('+');
        if (parts.Length < 3)
        {
            Console.WriteLine("El comando debe tener el formato: verbo+entidad+coordenadas.");
            return;
        }

        string verb = parts[0].ToLower();
        string entityType = parts[1];
        string destination = parts[2];

        if (_commands.TryGetValue(verb, out var command))
        {
            try
            {
                await command.ExecuteAsync(entityType, destination);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el comando: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"Comando no reconocido: '{verb}'.");
        }
    }
}