using System.Numerics;

namespace Exercise4._1;

internal class GameMap
{
#pragma warning disable CA1822 // Mark members as static
    internal Tower? FindTowerAt(Vector2 position)
#pragma warning restore CA1822 // Mark members as static
        => position.X >= 0 && position.Y >= 0
            ? new Tower()
            : null;
}
