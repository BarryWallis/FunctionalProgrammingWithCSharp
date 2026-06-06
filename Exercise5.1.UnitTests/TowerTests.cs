using System;

namespace Exercise5._1.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="global::Exercise5._1.Tower"/>.
/// </summary>
public class TowerTests
{
    /// <summary>
    /// Verifies that applying a power-up currently throws because the feature is not implemented yet.
    /// </summary>
    [Fact]
    public void ApplyPowerUp_WithPowerUp_ThrowsNotImplementedException()
    {
        global::Exercise5._1.Tower sut = new();
        global::Exercise5._1.PowerUp powerUp = new();

        _ = Assert.Throws<NotImplementedException>(() => sut.ApplyPowerUp(powerUp));
    }

    /// <summary>
    /// Verifies that applying a null power-up also throws because the feature is not implemented yet.
    /// </summary>
    [Fact]
    public void ApplyPowerUp_WithNullPowerUp_ThrowsNotImplementedException()
    {
        global::Exercise5._1.Tower sut = new();

        _ = Assert.Throws<NotImplementedException>(() => sut.ApplyPowerUp(null!));
    }

    /// <summary>
    /// Verifies that upgrading the tower currently throws because the feature is not implemented yet.
    /// </summary>
    [Fact]
    public void Upgrade_ThrowsNotImplementedException()
    {
        global::Exercise5._1.Tower sut = new();

        _ = Assert.Throws<NotImplementedException>(() => sut.Upgrade());
    }

    /// <summary>
    /// Verifies that an earlier failed power-up attempt does not change the current not-implemented behavior of upgrading the tower.
    /// </summary>
    [Fact]
    public void Upgrade_AfterApplyPowerUpAttempt_ThrowsNotImplementedException()
    {
        global::Exercise5._1.Tower sut = new();
        global::Exercise5._1.PowerUp powerUp = new();

        _ = Assert.Throws<NotImplementedException>(() => sut.ApplyPowerUp(powerUp));
        _ = Assert.Throws<NotImplementedException>(() => sut.Upgrade());
    }
}
