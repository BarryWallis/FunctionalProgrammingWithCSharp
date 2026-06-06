using LanguageExt;
using LanguageExt.Common;

namespace Exercise5._3;

/// <summary>
/// Provides functionality for retrying tower fire operations.
/// </summary>
public class Exercise3
{
    /// <summary>
    /// Retries the tower fire operation for a specified number of times.
    /// </summary>
    /// <param name="tower">The tower that is firing.</param>
    /// <param name="enemy">The enemy being fired upon.</param>
    /// <param name="retryCount">The number of times to retry the fire operation.</param>
    /// <returns>An <see cref="Either{L, R}"/> containing an <see cref="Error"/> if all retries fail, or <see cref="Unit"/> if the fire operation succeeds.</returns>
    public static Either<Error, Unit> RetryTowerFire(Tower tower, Enemy enemy, int retryCount)
    {
        for (int i = 0; i < retryCount; i++)
        {
            if (TowerFire(tower, enemy))
            {
                return Unit.Default; // Fire successful
            }
        }

        return Error.New("All retries failed"); // All retries failed
    }

    /// <summary>
    /// Simulates the logic for a tower firing at an enemy.
    /// </summary>
    /// <param name="tower">The tower that is firing.</param>
    /// <param name="enemy">The enemy being fired upon.</param>
    /// <returns><c>true</c> if the tower successfully fires; otherwise, <c>false</c>.</returns>
    public static bool TowerFire(Tower? tower, Enemy? enemy)
        => tower is null || enemy is null; // Simulate tower fire logic here  
}
