namespace Exercise4._3;

/// <summary>
/// Represents a wizard enemy with magical powers and spells.
/// </summary>
public class Wizard : Enemy
{
    public required string[] Spells { get; set; }
    public int MagicPower { get; set; }
}
