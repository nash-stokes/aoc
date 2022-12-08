namespace AoCProblemSolvers._2015Day21;

public class Item
{
    public Item(string type, string name, int cost, int damage, int armor)
    {
        Type = type;
        Name = name;
        Cost = cost;
        Damage = damage;
        Armor = armor;
    }

    private string Type { get; }
    private string Name { get; }
    private int Cost { get; }
    private int Damage { get; }
    private int Armor { get; }
}