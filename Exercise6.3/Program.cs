using Exercise6._3;

Tower tower1 = new(10, 5);
Tower tower2 = new(15, 7);

Tower longerRangeTower = CompareTowerRange(tower1, tower2, (t1, t2) => t1.Range > t2.Range ? t1 : t2);

Console.WriteLine(longerRangeTower);

/// <summary>
/// Compares two towers using the provided comparison function and returns the result of the comparison.
/// </summary>
/// <param name="tower1">The first tower to compare.</param>
/// <param name="tower2">The second tower to compare.</param>
/// <param name="compare">A function that compares two towers and returns the tower with the longer range.</param>
/// <returns>The tower with the longer range as determined by the comparison function.</returns>
static Tower CompareTowerRange(Tower tower1, Tower tower2, Func<Tower, Tower, Tower> compare)
    => tower1.Range > tower2.Range
       ? new Tower(tower1.DamageOutput, tower1.Range)
       : new Tower(tower2.DamageOutput, tower2.Range);
