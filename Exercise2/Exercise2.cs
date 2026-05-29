using System.Diagnostics.Contracts;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace Exercise2;

/// <summary>
/// Loads enemy data from JSON, applies the requested difficulty scaling, and stores the processed enemies.
/// </summary>
public class Exercise2
{
    private readonly EnemyRepository _enemyRepository;
    private readonly Action<string> _log;

    /// <summary>
    /// Initializes a new instance of the <see cref="Exercise2"/> class.
    /// </summary>
    public Exercise2()
        : this(new EnemyRepository(), _ => { })
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Exercise2"/> class with the supplied repository and logger.
    /// </summary>
    /// <param name="enemyRepository">The repository that stores processed enemies.</param>
    /// <param name="log">The delegate used to write status messages.</param>
    /// <exception cref="ArgumentNullException"><paramref name="enemyRepository"/> or <paramref name="log"/> is <see langword="null"/>.</exception>
    internal Exercise2(EnemyRepository enemyRepository, Action<string> log)
    {
        _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    // public void LoadAndProcessEnemyData(string filePath)
    // {
    //     string jsonData = File.ReadAllText(filePath);
    //     List<Enemy> enemies = JsonConvert.DeserializeObject<List<Enemy>>(jsonData);
    //     foreach (var enemy in enemies)
    //     {
    //         enemy.Health *= GameState.DifficultyLevel;
    //         GameState.ActiveEnemies.Add(enemy);
    //     }
    //     Console.WriteLine($"Loaded {enemies.Count} enemies");
    // }

    /// <summary>
    /// Reads enemy definitions from a JSON file, scales each enemy's health by the supplied difficulty level,
    /// stores the processed enemies in the repository, and writes a log message with the number of loaded enemies.
    /// </summary>
    /// <param name="filePath">The path to the JSON file that contains an array of enemy definitions.</param>
    /// <param name="difficultyLevel">The multiplier applied to each enemy's health.</param>
    /// <exception cref="ArgumentException"><paramref name="filePath"/> is null, empty, or whitespace.</exception>
    /// <exception cref="InvalidOperationException">The JSON payload cannot be deserialized into a list of enemies.</exception>
    public void LoadAndProcessEnemyData(string filePath, double difficultyLevel)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        string jsonData = ReadAllText(filePath);
        List<Enemy> enemies = DeserializeJsonData(jsonData);
        List<Enemy> processedEnemies = ProcessEnemies(enemies, difficultyLevel);
        _enemyRepository.AddEnemies(processedEnemies);
        Log($"Loaded {enemies.Count} enemies");
    }

    /// <summary>
    /// Writes a status message using the configured logger.
    /// </summary>
    /// <param name="v">The message to write.</param>
    private void Log(string v) => _log(v);

    [Pure]
    /// <summary>
    /// Creates scaled copies of the provided enemies using the supplied difficulty level.
    /// </summary>
    /// <param name="enemies">The enemies to scale.</param>
    /// <param name="difficultyLevel">The multiplier applied to each enemy's health.</param>
    /// <returns>A new list containing the scaled enemy instances.</returns>
    private static List<Enemy> ProcessEnemies(List<Enemy> enemies, double difficultyLevel) 
        => [.. enemies.Select(e => new Enemy
                                {
                                    Health = e.Health * difficultyLevel,
                                    // Copy other properties...
                                })];

    [Pure]
    /// <summary>
    /// Deserializes a JSON payload into a list of enemies.
    /// </summary>
    /// <param name="jsonData">The JSON payload to deserialize.</param>
    /// <returns>The deserialized list of enemies.</returns>
    /// <exception cref="InvalidOperationException">The JSON payload cannot be deserialized into a list of enemies.</exception>
    private static List<Enemy> DeserializeJsonData(string jsonData)
        => JsonConvert.DeserializeObject<List<Enemy>>(jsonData) 
           ?? throw new InvalidOperationException("Failed to deserialize JSON data.");

    /// <summary>
    /// Reads all text from the specified file.
    /// </summary>
    /// <param name="filePath">The path to the file to read.</param>
    /// <returns>The contents of the file.</returns>
    private static string ReadAllText(string filePath) => File.ReadAllText(filePath);
}
