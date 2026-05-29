using Xunit;

namespace Exercise1.Tests;

/// <summary>
/// Verifies damage calculation behavior for the pure Exercise1 entry point.
/// </summary>
public class Exercise1Tests
{
    /// <summary>
    /// Verifies the method multiplies tower damage, enemy multiplier, and difficulty modifier.
    /// </summary>
    [Theory]
    [InlineData(10, 2, 1.0, 20.0)]
    [InlineData(10, 2, 1.5, 30.0)]
    [InlineData(8, 3, 0.0, 0.0)]
    [InlineData(7, 4, 0.5, 14.0)]
    public void CalculateDamage_ReturnsExpectedDamage(
        int baseDamage,
        int damageMultiplier,
        double difficultyModifier,
        double expectedDamage)
    {
        Tower tower = CreateTower(baseDamage);
        Enemy enemy = CreateEnemy(damageMultiplier);

        double actualDamage = Exercise1.CalculateDamage(tower, enemy, difficultyModifier);

        Assert.Equal(expectedDamage, actualDamage);
    }

    // Creates a tower configured with the damage value needed for the test case.
    private static Tower CreateTower(int baseDamage) => new() { BaseDamage = baseDamage };

    // Creates an enemy configured with the multiplier needed for the test case.
    private static Enemy CreateEnemy(int damageMultiplier) => new() { DamageMultiplier = damageMultiplier };
}
