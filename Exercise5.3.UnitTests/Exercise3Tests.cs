using LanguageExt;
using LanguageExt.Common;

namespace Exercise5._3.UnitTests;

/// <summary>
/// Unit tests for <see cref="Exercise3"/>.
/// </summary>
public class Exercise3Tests
{
    [Fact]
    public void RetryTowerFire_ShouldReturnUnit_WhenFireIsSuccessful()
    {
        Tower tower = null!; // TowerFire returns true if tower is null
        Enemy enemy = null!;
        int retryCount = 3;

        Either<Error, Unit> result = Exercise3.RetryTowerFire(tower, enemy, retryCount);

        Assert.True(result.IsRight);
    }

    [Fact]
    public void RetryTowerFire_ShouldReturnError_WhenFireFails()
    {
        Tower tower = new(); // TowerFire returns false if both are not null
        Enemy enemy = new();
        int retryCount = 3;

        Either<Error, Unit> result = Exercise3.RetryTowerFire(tower, enemy, retryCount);

        Assert.True(result.IsLeft);
        _ = result.IfLeft(static error => Assert.Equal("All retries failed", error.Message));
    }

    [Fact]
    public void TowerFire_ShouldReturnTrue_WhenTowerIsNull()
    {
        Tower? tower = null;
        Enemy? enemy = new();

        bool result = Exercise3.TowerFire(tower, enemy);

        Assert.True(result);
    }

    [Fact]
    public void TowerFire_ShouldReturnTrue_WhenEnemyIsNull()
    {
        Tower? tower = new();
        Enemy? enemy = null;

        bool result = Exercise3.TowerFire(tower, enemy);

        Assert.True(result);
    }

    [Fact]
    public void TowerFire_ShouldReturnFalse_WhenBothAreNotNull()
    {
        Tower? tower = new();
        Enemy? enemy = new();

        bool result = Exercise3.TowerFire(tower, enemy);

        Assert.False(result);
    }
}
