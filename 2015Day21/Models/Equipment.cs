using System.Text.RegularExpressions;
using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2015Day21;

public class Equipment
{
    public List<Item> shopInventory = new List<Item>();
    public List<Item> weapons = new List<Item>();
    public List<Item> armor = new List<Item>();
    public List<Item> rings = new List<Item>();

    public Equipment()
    {
        BuildOutInventory();
    }
    public void BuildOutInventory()
    {
        FileReader _fileReader = new FileReader();
        var _rawText = _fileReader.Read("../../../2015Day21/ShopInventory.txt");
        var _text = _rawText.ToArray();
        var itemType = String.Empty;
        var itemName = "";
        var itemCost = 0;
        var itemDamage = 0;
        var itemArmor = 0;
        String[] itemInfo;
        Regex sWhitespace = new Regex(@"\s\s+");
        foreach (var line in _text)
        {
            if (line.Contains(':'))
            {
                itemType = line.Split(':', 2)[0];
                continue;
            }
            else if (line.Any(x => char.IsLetter(x)))
            {
                var lineWithoutWhitespace = sWhitespace.Replace(line, "|");
                itemInfo = lineWithoutWhitespace.Split('|');;
                itemName = itemInfo[0];
                itemCost = Int32.Parse(itemInfo[1]);
                itemDamage = Int32.Parse(itemInfo[2]);
                itemArmor = Int32.Parse(itemInfo[3]);
                var item = new Item(itemType, itemName, itemCost, itemDamage, itemArmor);
                shopInventory.Add(item);
            }
        }

        armor = shopInventory.Where(x => x.Type.Equals("Armor")).ToList();
        weapons = shopInventory.Where(x => x.Type.Equals("Weapons")).ToList();
        rings = shopInventory.Where(x => x.Type.Equals("Rings")).ToList();
    }

}