using System.Numerics;

namespace Exercise4._1.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="global::Exercise4._2.GameState"/>.
/// </summary>
public class GameStateTests
{
    /// <summary>
    /// Verifies that a tower is returned when both position coordinates are within the valid game area.
    /// </summary>
    [Fact]
    public void FindTowerAt_PositionCoordinatesAreNonNegative_ReturnsTower()
    {
        global::Exercise4._2.GameState sut = new();
        Vector2 position = new(0.0f, 1.0f);

        global::Exercise4._2.Tower? result = sut.FindTowerAt(position);

        global::Exercise4._2.Tower tower = Assert.IsType<global::Exercise4._2.Tower>(result);
        Assert.NotNull(tower);
    }

    /// <summary>
    /// Verifies that no tower is returned when the X coordinate is negative.
    /// </summary>
    [Fact]
    public void FindTowerAt_XCoordinateIsNegative_ReturnsNull()
    {
        global::Exercise4._2.GameState sut = new();
        Vector2 position = new(-0.01f, 1.0f);

        global::Exercise4._2.Tower? result = sut.FindTowerAt(position);

        Assert.Null(result);
    }

    /// <summary>
    /// Verifies that no tower is returned when the Y coordinate is negative.
    /// </summary>
    [Fact]
    public void FindTowerAt_YCoordinateIsNegative_ReturnsNull()
    {
        global::Exercise4._2.GameState sut = new();
        Vector2 position = new(1.0f, -0.01f);

        global::Exercise4._2.Tower? result = sut.FindTowerAt(position);

        Assert.Null(result);
    }

    /// <summary>
    /// Verifies that updating a tower currently reports the method is not implemented.
    /// </summary>
    [Fact]
    public void UpdateTower_TowerIsProvided_ThrowsNotImplementedException()
    {
        global::Exercise4._2.GameState sut = new();
        global::Exercise4._2.Tower tower = new();

        NotImplementedException exception = Assert.Throws<NotImplementedException>(() => sut.UpdateTower(tower));

        Assert.NotNull(exception);
    }
}
