using System.Reflection;

using Xunit;

namespace Exercise2.Tests;

/// <summary>
/// Verifies JSON loading and enemy scaling behavior for <see cref="global::Exercise2.Exercise2"/>.
/// </summary>
public class Exercise2Tests
{
    /// <summary>
    /// Verifies the constructor rejects a null repository dependency.
    /// </summary>
    [Fact]
    public void Constructor_WithNullRepository_ThrowsArgumentNullException()
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new global::Exercise2.Exercise2(null!, _ => { }));

        Assert.Equal("enemyRepository", exception.ParamName);
    }

    /// <summary>
    /// Verifies the constructor rejects a null logger dependency.
    /// </summary>
    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new global::Exercise2.Exercise2(new global::Exercise2.EnemyRepository(), null!));

        Assert.Equal("log", exception.ParamName);
    }

    /// <summary>
    /// Verifies the public entry point rejects blank file paths.
    /// </summary>
    [Fact]
    public void LoadAndProcessEnemyData_WithWhitespaceFilePath_ThrowsArgumentException()
    {
        global::Exercise2.Exercise2 sut = new(new global::Exercise2.EnemyRepository(), _ => { });

        _ = Assert.Throws<ArgumentException>(() => sut.LoadAndProcessEnemyData(" ", 2.0));
    }

    /// <summary>
    /// Verifies a null JSON payload is reported as an invalid operation.
    /// </summary>
    [Fact]
    public void LoadAndProcessEnemyData_WithNullJsonPayload_ThrowsInvalidOperationException()
    {
        global::Exercise2.Exercise2 sut = new(new global::Exercise2.EnemyRepository(), _ => { });
        string filePath = WriteTempFile("null");

        try
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => sut.LoadAndProcessEnemyData(filePath, 2.0));

            Assert.Equal("Failed to deserialize JSON data.", exception.Message);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    /// <summary>
    /// Verifies the JSON deserializer recreates enemies from the payload.
    /// </summary>
    [Fact]
    public void DeserializeJsonData_ReturnsExpectedEnemies()
    {
        const string json = """
            [{"Health":10.0},{"Health":5.5}]
            """;

        List<global::Exercise2.Enemy> enemies = InvokePrivateStatic<List<global::Exercise2.Enemy>>("DeserializeJsonData", json);

        Assert.Collection(
            enemies,
            enemy => Assert.Equal(10.0, enemy.Health),
            enemy => Assert.Equal(5.5, enemy.Health));
    }

    /// <summary>
    /// Verifies enemy processing scales health and returns new enemy instances.
    /// </summary>
    [Fact]
    public void ProcessEnemies_ScalesHealthAndCreatesNewInstances()
    {
        List<global::Exercise2.Enemy> enemies =
        [
            new() { Health = 10.0 },
            new() { Health = 3.5 },
        ];

        List<global::Exercise2.Enemy> processedEnemies = InvokePrivateStatic<List<global::Exercise2.Enemy>>("ProcessEnemies", enemies, 2.0);

        Assert.Collection(
            processedEnemies,
            enemy => Assert.Equal(20.0, enemy.Health),
            enemy => Assert.Equal(7.0, enemy.Health));

        Assert.NotSame(enemies[0], processedEnemies[0]);
        Assert.NotSame(enemies[1], processedEnemies[1]);
    }

    private static T InvokePrivateStatic<T>(string methodName, params object[] arguments)
    {
        MethodInfo method = typeof(global::Exercise2.Exercise2).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException($"Unable to locate method '{methodName}'.");

        try
        {
            return (T)method.Invoke(null, arguments)!;
        }
        catch (TargetInvocationException exception) when (exception.InnerException is not null)
        {
            throw exception.InnerException;
        }
    }

    private static string WriteTempFile(string content)
    {
        string filePath = Path.GetTempFileName();
        File.WriteAllText(filePath, content);
        return filePath;
    }
}
