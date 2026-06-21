namespace Exercise6._2;

/// <summary>
/// Represents an enemy in Exercise 6.2.
/// </summary>
public record Enemy(int Health, int AttackPower)
{
    /// <summary>
    /// Executes the provided action for each enemy in the collection.
    /// </summary>
    /// <param name="enemies">The enemies to process.</param>
    /// <param name="action">The action to execute for each enemy.</param>
    public static void TakeAction(IList<Enemy> enemies, Action<Enemy> action)
    {
        foreach (Enemy enemy in enemies)
        {
            action(enemy);
        }
    }
}
