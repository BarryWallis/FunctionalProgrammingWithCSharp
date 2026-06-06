using LanguageExt.Common;

namespace Exercise5._1;

/// <summary>
/// Provides the tower upgrade workflow for Chapter 5.
/// </summary>
public class Exercise1
{
    /// <summary>
    /// Attempts to upgrade the specified tower and returns the outcome as a result.
    /// </summary>
    /// <param name="tower">The tower to upgrade.</param>
    /// <returns>A successful result when the upgrade succeeds; otherwise, a payment failure result.</returns>
    public static Result<bool> UpgradeTower(Tower tower)
        // Tower upgrading logic...
        => tower.Upgrade() ? new Result<bool>(true)
                           : new Result<bool>(new PaymentFailedException());
}
