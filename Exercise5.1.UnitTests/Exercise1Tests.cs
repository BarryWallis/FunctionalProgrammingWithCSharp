using System;
using Exercise5._1;

namespace Exercise5._1.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="global::Exercise5._1.Exercise1"/>.
/// </summary>
public class Exercise1Tests
{
    /// <summary>
    /// Verifies that the method currently propagates the tower implementation failure for a valid tower instance.
    /// </summary>
    [Fact]
    public void UpgradeTower_TowerIsProvided_ThrowsNotImplementedException()
    {
        Tower tower = new();

        NotImplementedException exception = Assert.Throws<NotImplementedException>(() => global::Exercise5._1.Exercise1.UpgradeTower(tower));

        Assert.NotNull(exception);
    }

    /// <summary>
    /// Verifies that the method throws when the required tower instance is missing.
    /// </summary>
    [Fact]
    public void UpgradeTower_TowerIsNull_ThrowsNullReferenceException()
    {
        NullReferenceException exception = Assert.Throws<NullReferenceException>(() => global::Exercise5._1.Exercise1.UpgradeTower(null!));

        Assert.NotNull(exception);
    }

    /// <summary>
    /// Verifies that the method propagates the current tower upgrade implementation failure instead of wrapping it.
    /// </summary>
    [Fact]
    public void UpgradeTower_TowerUpgradeIsNotImplemented_DoesNotWrapFailure()
    {
        Tower tower = new();

        Exception exception = Assert.Throws<NotImplementedException>(() => global::Exercise5._1.Exercise1.UpgradeTower(tower));

        Assert.IsNotType<global::Exercise5._1.PaymentFailedException>(exception);
    }

    /// <summary>
    /// Verifies that a missing tower reference fails before any payment failure result can be created.
    /// </summary>
    [Fact]
    public void UpgradeTower_TowerIsNull_DoesNotWrapFailure()
    {
        Exception exception = Assert.Throws<NullReferenceException>(() => global::Exercise5._1.Exercise1.UpgradeTower(null!));

        Assert.IsNotType<global::Exercise5._1.PaymentFailedException>(exception);
    }
}
