// Write a program that uses a higher-order function to sort a list of towers in Steve’s game based on
// their damage output.The sorting function should be passed as a delegate.
using Exercise6._1;

List<Tower> towers = [];
Random random = new();

for (int i = 0; i < 10; i++)
{
    towers.Add(new Tower(random.Next(1, 101)));
}

IList<Tower> SortedTowers = Tower.Sort(towers, static (a, b) => a.DamageOutput.CompareTo(b.DamageOutput));
foreach (Tower tower in SortedTowers)
{
    Console.WriteLine($"Tower with damage output: {tower.DamageOutput}");
}
