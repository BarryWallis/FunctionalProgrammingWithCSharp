using System;
using Exercise4._2;

namespace Exercise4._1.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="global::Exercise4._2.Exercise2"/>.
/// </summary>
public class Exercise2Tests
{
    /// <summary>
    /// Verifies that the method rejects a missing tower before invoking exercise logic.
    /// </summary>
    [Fact]
    public void ApplyPowerUp_TowerIsNull_ThrowsArgumentNullException()
    {
        global::Exercise4._2.Exercise2 sut = new();
        PowerUp powerUp = new();

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => sut.ApplyPowerUp(null!, powerUp));

        Assert.Equal("tower", exception.ParamName);
    }

    /// <summary>
    /// Verifies that the method rejects a missing power-up before touching the tower.
    /// </summary>
    [Fact]
    public void ApplyPowerUp_PowerUpIsNull_ThrowsArgumentNullException()
    {
        global::Exercise4._2.Exercise2 sut = new();
        global::Exercise4._2.Tower tower = new();

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => sut.ApplyPowerUp(tower, null!));

        Assert.Equal("powerUp", exception.ParamName);
    }

    /// <summary>
    /// Verifies that the method currently propagates the tower implementation failure for non-null inputs.
    /// </summary>
    [Fact]
    public void ApplyPowerUp_ArgumentsAreValid_ThrowsNotImplementedException()
    {
        global::Exercise4._2.Exercise2 sut = new();
        global::Exercise4._2.Tower tower = new();
        PowerUp powerUp = new();

        NotImplementedException exception = Assert.Throws<NotImplementedException>(() => sut.ApplyPowerUp(tower, powerUp));

        Assert.NotNull(exception);
    }

}
