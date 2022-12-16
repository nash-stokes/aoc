namespace AoCProblemSolvers._2015Day21
{
    internal class Player : Character
    {
        int goldValue = 0;
        private List<Item> equipment = new List<Item>();
        public Player() : base("Player", 100, 0, 0)
        {
        }

        public void Equip(int equipmentArmor, int equipmentDamage)
        {
            _damage += equipmentDamage;
            _armor += equipmentArmor;
        }
    }
}
