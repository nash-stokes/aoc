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

    public string Type { get; }
    public string Name { get; }
    public int Cost { get; }
    public int Damage { get; }
    public int Armor { get; }
}