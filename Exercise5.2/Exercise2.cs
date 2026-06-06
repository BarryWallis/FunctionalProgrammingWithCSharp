using LanguageExt;
using LanguageExt.Common;

namespace Exercise5._2;

/// <summary>
/// Provides functionality for processing enemy spawns using a functional pipeline.
/// </summary>
public class Exercise2
{
    /// <summary>
    /// Processes enemy spawn data through parsing, validation, and spawning steps.
    /// </summary>
    /// <param name="enemyData">The raw string data representing an enemy.</param>
    /// <returns>An <see cref="Either{Error, Unit}"/> indicating success or failure at any stage of the pipeline.</returns>
    public Either<Error, Unit> ProcessEnemySpawn(string enemyData)
        => ParseEnemyData(enemyData)
           .Bind(ValidateEnemySpawn)
           .Bind(SpawnEnemy);

    /// <summary>
    /// Spawns an enemy based on the validated enemy object.
    /// </summary>
    /// <param name="enemy">The validated enemy to spawn.</param>
    /// <returns>An <see cref="Either{Error, Unit}"/> containing the unit of work result or an error.</returns>
    private Either<Error, Unit> SpawnEnemy(Enemy enemy) => Error.New($"Cannot spawn enemy: {enemy}");

    /// <summary>
    /// Validates the parsed enemy data.
    /// </summary>
    /// <param name="parsedData">The data parsed from the raw input.</param>
    /// <returns>An <see cref="Either{Error, Enemy}"/> containing the validated enemy or an error.</returns>
    private Either<Error, Enemy> ValidateEnemySpawn(EnemyData parsedData) 
        => Error.New($"Cannot validate enemy data: {parsedData}");

    /// <summary>
    /// Parses the raw enemy data string into an <see cref="EnemyData"/> object.
    /// </summary>
    /// <param name="enemyData">The raw string data representing an enemy.</param>
    /// <returns>An <see cref="Either{Error, EnemyData}"/> containing the parsed data or an error.</returns>
    private static Either<Error, EnemyData> ParseEnemyData(string enemyData) 
        => Error.New($"Cannot parse enemy data: {enemyData}");
}
