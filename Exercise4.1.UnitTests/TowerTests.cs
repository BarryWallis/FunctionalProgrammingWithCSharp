using System;

namespace Exercise4._1.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="global::Exercise4._2.Tower"/>.
/// </summary>
public class TowerTests
{
    /// <summary>
    /// Verifies that applying a power-up currently throws because the feature is not implemented yet.
    /// </summary>
    [Fact]
    public void ApplyPowerUp_WithPowerUp_ThrowsNotImplementedException()
    {
        global::Exercise4._2.Tower sut = new();
        global::Exercise4._2.PowerUp powerUp = new();

        _ = Assert.Throws<NotImplementedException>(() => sut.ApplyPowerUp(powerUp));
    }

    /// <summary>
    /// Verifies that applying a null power-up also throws because the feature is not implemented yet.
    /// </summary>
    [Fact]
    public void ApplyPowerUp_WithNullPowerUp_ThrowsNotImplementedException()
    {
        global::Exercise4._2.Tower sut = new();

        _ = Assert.Throws<NotImplementedException>(() => sut.ApplyPowerUp(null!));
    }
}

