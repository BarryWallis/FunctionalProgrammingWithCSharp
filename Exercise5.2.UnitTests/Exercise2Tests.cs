using Exercise5._2;
using LanguageExt;
using LanguageExt.Common;

namespace Exercise5._2.UnitTests;

/// <summary>
/// Contains unit tests for <see cref="Exercise2"/>.
/// </summary>
public class Exercise2Tests
{
    /// <summary>
    /// Verifies that <see cref="Exercise2.ProcessEnemySpawn"/> returns an error when parsing fails.
    /// </summary>
    [Fact]
    public void ProcessEnemySpawn_AnyInput_ReturnsError()
    {
        Exercise2 exercise = new();
        string input = "dummy data";

        Either<Error, Unit> result = exercise.ProcessEnemySpawn(input);

        Assert.True(result.IsLeft);
        _ = result.IfLeft(static error => Assert.Contains("Cannot parse enemy data", error.Message));
    }
}
