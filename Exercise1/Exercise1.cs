using System.Diagnostics.Contracts;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise1;

/// <summary>
/// Provides pure calculation helpers for the exercise.
/// </summary>
public class Exercise1
{
    /// <summary>
    /// Calculates the final damage dealt by a tower against an enemy for the supplied difficulty modifier.
    /// </summary>
    /// <param name="tower">The tower providing the base damage.</param>
    /// <param name="enemy">The enemy providing the incoming damage multiplier.</param>
    /// <param name="difficultyModifier">The difficulty multiplier applied to the result.</param>
    /// <returns>The final damage value after applying all multipliers.</returns>
    /// <example>
    /// <code>
    /// Tower tower = new() { BaseDamage = 10 };
    /// Enemy enemy = new() { DamageMultiplier = 2 };
    /// double damage = Exercise1.CalculateDamage(tower, enemy, 1.5);
    /// </code>
    /// </example>
    [Pure]
    public static double CalculateDamage(Tower tower, Enemy enemy, double difficultyModifier)
        => tower.BaseDamage * enemy.DamageMultiplier * difficultyModifier;
}
