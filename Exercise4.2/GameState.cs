using System.Numerics;

namespace Exercise4._2;

/// <summary>
/// Represents the mutable game state used to locate and update towers.
/// </summary>
internal class GameState
{
#pragma warning disable CA1822 // Mark members as static
    /// <summary>
    /// Finds the tower located at the specified position.
    /// </summary>
    /// <param name="position">The position to inspect.</param>
    /// <returns>
    /// A tower when the position is within the valid game area; otherwise, <see langword="null"/>.
    /// </returns>
    internal Tower? FindTowerAt(Vector2 position)
#pragma warning restore CA1822 // Mark members as static
        => position.X >= 0 && position.Y >= 0
            ? new Tower()
            : null;

    /// <summary>
    /// Persists the latest state for the specified tower.
    /// </summary>
    /// <param name="tower">The tower whose state should be updated.</param>
    internal void UpdateTower(Tower tower) => throw new NotImplementedException();
}
