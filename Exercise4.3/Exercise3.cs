namespace Exercise4._3;
public class Exercise3
{
    public static string DescribeEnemy(Enemy? enemy) => enemy switch
    {
        null => "No enemy",
        Goblin goblin => $"Goblin with {(goblin.HasWeapon ? "a" : "no")} weapon and {goblin.Strength} strength",
        Wizard wizard => $"Wizard with {wizard.MagicPower} magic power and the following spells: " +
                         $"{string.Join(", ", wizard.Spells)}",
        Dragon dragon => $"Dragon with {dragon.FireBreathDamage} fire breath damage, and {dragon.WingSpan} wing span",
        _ => "Unknown enemy type"
    };
}
