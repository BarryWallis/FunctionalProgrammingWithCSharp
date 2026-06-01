namespace Exercise4._2;

/// <summary>
/// Coordinates tower-related operations for the exercise.
/// </summary>
public class Exercise2
{
    /// <summary>
    /// Tracks the current game state for tower updates.
    /// </summary>
    private readonly GameState _gameState = new();

    /// <summary>
    /// Applies the specified power-up to the provided tower and persists the updated tower state.
    /// </summary>
    /// <param name="tower">The tower that receives the power-up.</param>
    /// <param name="powerUp">The power-up to apply to the tower.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="tower"/> or <paramref name="powerUp"/> is <see langword="null"/>.
    /// </exception>
    public void ApplyPowerUp(Tower tower, PowerUp powerUp)
    {
        ArgumentNullException.ThrowIfNull(tower);
        ArgumentNullException.ThrowIfNull(powerUp);

        tower.ApplyPowerUp(powerUp);
        _gameState.UpdateTower(tower);
    }
}
