using System;
using System.Numerics;
using Exercise4._1;

namespace Exercise4._1.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="global::Exercise4._1.Exercise1"/>.
/// </summary>
public class Exercise1Tests
{
    /// <summary>
    /// Verifies that the method returns no tower when the position is outside the map lookup range.
    /// </summary>
    [Fact]
    public void GetTowerByPosition_PositionIsOutsideLookupRange_ReturnsNone()
    {
        global::Exercise4._1.Exercise1 sut = new();
        Vector2 position = new(1.5f, -2.25f);

        LanguageExt.Option<Tower> result = sut.GetTowerByPosition(position);

        Assert.True(result.IsNone);
    }

    /// <summary>
    /// Verifies that the method returns a tower when the position maps to a tower location.
    /// </summary>
    [Fact]
    public void GetTowerByPosition_PositionIsWithinLookupRange_ReturnsSome()
    {
        global::Exercise4._1.Exercise1 sut = new();
        Vector2 position = new(2.5f, 3.75f);

        LanguageExt.Option<Tower> result = sut.GetTowerByPosition(position);
        Tower tower = result.Match(static value => value, static () => throw new Xunit.Sdk.XunitException("Expected a tower."));

        Assert.True(result.IsSome);
        Assert.NotNull(tower);
    }
}
