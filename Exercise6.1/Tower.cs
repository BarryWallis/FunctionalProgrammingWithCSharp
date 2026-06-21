namespace Exercise6._1;

/// <summary>
/// Represents a tower that can receive gameplay upgrades.
/// </summary>
/// <param name="DamageOutput">The initial damage output of the tower.</param>
public record Tower(int DamageOutput)
{
    /// <summary>
    /// Delegate for comparing two towers.
    /// </summary>
    /// <param name="a">The first tower to compare.</param>
    /// <param name="b">The second tower to compare.</param>
    /// <returns>A signed integer indicating the relative order of the towers.</returns>
    public delegate int Compare(Tower a, Tower b);

    /// <summary>
    /// Applies the specified power-up to the tower.
    /// </summary>
    /// <param name="powerUp">The power-up to apply.</param>
    internal void ApplyPowerUp(PowerUp powerUp) => throw new NotImplementedException();

    /// <summary>
    /// Attempts to upgrade the tower.
    /// </summary>
    /// <returns>True if the upgrade was successful; otherwise, false.</returns>
    internal bool Upgrade() => throw new NotImplementedException();

    /// <summary>
    /// Sorts a collection of towers using the specified comparison delegate.
    /// </summary>
    /// <param name="towers">The towers to sort.</param>
    /// <param name="compare">The comparison delegate used to sort the towers.</param>
    /// <returns>A sorted list of towers.</returns>
    public static IList<Tower> Sort(IEnumerable<Tower> towers, Compare compare)
    {
        List<Tower> towersList = [.. towers];
        towersList.Sort((a, b) => compare(a, b));
        return towersList;
    }
}
