using System.Numerics;

using LanguageExt;

namespace Exercise4._1;

/// <summary>
/// Provides methods to retrieve towers by position.
/// </summary>
public class Exercise1
{
    private readonly GameMap _gameMap = new();

    public Option<Tower> GetTowerByPosition(Vector2 position)
    {
        Tower? tower = _gameMap.FindTowerAt(position);
        return tower is null ? Option<Tower>.None :  Option<Tower>.Some(tower);
    }
}
