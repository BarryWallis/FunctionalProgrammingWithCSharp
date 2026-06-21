//Create a method that takes an Action and a enemies of enemies. The Action should perform a calculation 
//on each enemy’s health and print the result. Test your method using several different Actions, such 
//as calculating damage taken from different tower types.

using Exercise6._2;

List<Enemy> enemies = new(10);
Random random = new();

for (int i = 0; i < enemies.Capacity - 1; i++)
{
    enemies.Add(new Enemy(random.Next(1, 11), random.Next(1, 10)));
}

Enemy.TakeAction(enemies, enemy =>
{
    int damage = random.Next(1, 11); // Example damage from a tower
    int remainingHealth = enemy.Health - damage;
    Console.WriteLine($"Enemy with {enemy.Health} health takes {damage} damage, remaining health: {remainingHealth}");
});
