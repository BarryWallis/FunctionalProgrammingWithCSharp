using Exercise4._3;

namespace Exercise4._1.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="global::Exercise4._3.Exercise3"/>.
/// </summary>
public class Exercise3Tests
{
    /// <summary>
    /// Verifies that the method returns the fallback description when the enemy is missing.
    /// </summary>
    [Fact]
    public void DescribeEnemy_EnemyIsNull_ReturnsNoEnemy()
    {
        Enemy? enemy = null;

        string result = global::Exercise4._3.Exercise3.DescribeEnemy(enemy);

        Assert.Equal("No enemy", result);
    }

    /// <summary>
    /// Verifies that goblins with weapons are described using the armed wording and strength value.
    /// </summary>
    [Fact]
    public void DescribeEnemy_EnemyIsGoblinWithWeapon_ReturnsGoblinDescription()
    {
        Goblin enemy = new()
        {
            HasWeapon = true,
            Strength = 12,
        };

        string result = global::Exercise4._3.Exercise3.DescribeEnemy(enemy);

        Assert.Equal("Goblin with a weapon and 12 strength", result);
    }

    /// <summary>
    /// Verifies that goblins without weapons are described using the unarmed wording and strength value.
    /// </summary>
    [Fact]
    public void DescribeEnemy_EnemyIsGoblinWithoutWeapon_ReturnsGoblinDescription()
    {
        Goblin enemy = new()
        {
            HasWeapon = false,
            Strength = 3,
        };

        string result = global::Exercise4._3.Exercise3.DescribeEnemy(enemy);

        Assert.Equal("Goblin with no weapon and 3 strength", result);
    }

    /// <summary>
    /// Verifies that wizards are described with their magic power and a comma-separated spell list.
    /// </summary>
    [Fact]
    public void DescribeEnemy_EnemyIsWizard_ReturnsWizardDescription()
    {
        Wizard enemy = new()
        {
            MagicPower = 99,
            Spells = ["Fireball", "Teleport", "Shield"],
        };

        string result = global::Exercise4._3.Exercise3.DescribeEnemy(enemy);

        Assert.Equal("Wizard with 99 magic power and the following spells: Fireball, Teleport, Shield", result);
    }

    /// <summary>
    /// Verifies that dragons are described with their fire breath damage and wing span.
    /// </summary>
    [Fact]
    public void DescribeEnemy_EnemyIsDragon_ReturnsDragonDescription()
    {
        Dragon enemy = new()
        {
            FireBreathDamage = 250,
            WingSpan = 40,
        };

        string result = global::Exercise4._3.Exercise3.DescribeEnemy(enemy);

        Assert.Equal("Dragon with 250 fire breath damage, and 40 wing span", result);
    }

    /// <summary>
    /// Verifies that unrecognized enemy subclasses use the unknown fallback description.
    /// </summary>
    [Fact]
    public void DescribeEnemy_EnemyIsUnknownSubtype_ReturnsUnknownEnemyType()
    {
        Enemy enemy = new UnknownEnemy();

        string result = global::Exercise4._3.Exercise3.DescribeEnemy(enemy);

        Assert.Equal("Unknown enemy type", result);
    }

    /// <summary>
    /// Provides an enemy subtype that is intentionally not handled by the production switch expression.
    /// </summary>
    private sealed class UnknownEnemy : Enemy
    {
    }
}
