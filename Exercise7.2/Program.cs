using Exercise7._2;

using LanguageExt;

using static LanguageExt.Prelude;

static Validation<Seq<string>, Tower> ValidateDamage(Tower tower)
    => tower.Damage < 100
        ? Success<Seq<string>, Tower>(tower)
        : Fail<Seq<string>, Tower>(Seq1("Damage must be less than 100."));

static Validation<Seq<string>, Tower> ValidateName(Tower tower)
    => tower.Name.Length > 5 && !tower.Name.Contains("BannedWord")
        ? Success<Seq<string>, Tower>(tower)
        : Fail<Seq<string>, Tower>(Seq1("Name must be longer than 5 characters and must not contain banned words."));


List<Tower> towers = [
    new Tower(1, "Tower 1", 100),
    new Tower(2, "Tower 2", 20),
    new Tower(3, "Tower 3 BannedWord", 300)
];

foreach (Tower tower in towers)
{
    _ = Success<Seq<string>, Func<Tower, Func<Tower, Tower>>>(damageTower => _ => damageTower)
        .Apply(ValidateDamage(tower))
        .Apply(ValidateName(tower))
        .Match(
            Succ: _ => Console.WriteLine($"Tower {tower.Id} is valid."),
            Fail: errors => Console.WriteLine($"Tower {tower.Id} is invalid: {string.Join(", ", errors)}")
        );
}
