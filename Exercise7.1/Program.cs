using Exercise7._1;

using LanguageExt;

static Either<string, List<Tower>> UpgradeTowers(List<Tower> towers)
{
    if (towers.Count == 0)
    {
        return "No towers to upgrade.";
    }

    List<Tower> upgradedTowers = [.. towers.Map(static t => t with { Name = t.Name + " (Upgraded)" })];
    return upgradedTowers;
}

List<Tower> towers = [
    new Tower(1, "Tower 1", 100),
    new Tower(2, "Tower 2", 200),
    new Tower(3, "Tower 3", 300)
];

UpgradeTowers(towers).Match(
    Right: static upgradedTowers => upgradedTowers.ForEach(static t => Console.WriteLine(t.Name)),
    Left: static error => Console.WriteLine($"Error: {error}"));

Console.WriteLine();

UpgradeTowers([]).Match(
    Right: static upgradedTowers => upgradedTowers.ForEach(static t => Console.WriteLine(t.Name)),
    Left: static error => Console.WriteLine($"Error: {error}"));
