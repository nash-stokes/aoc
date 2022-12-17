namespace AoCProblemSolvers._2015Day21
{
    class Engine
    {
        private Character _boss;
        private Equipment _equipment;
        private List<RoundData> _roundDataCollection = new ();
        public Engine(int bossHitPoints, int bossDamage, int bossArmor)
        {
            _boss = new Character("BOSS", bossHitPoints, bossDamage, bossArmor);
            _equipment = new Equipment();
        }

        public bool Run(int equipmentArmor, int equipmentDamage)
        {
            bool playerTurn = false;
            var bossHitPoints = _boss._hitPoints;
            var bossDamage = _boss._damage;
            var bossArmor = _boss._armor;
            var playerHitPoints = 100;
            var playerDamage = equipmentDamage;
            var playerArmor = equipmentArmor;

            while (playerHitPoints > 0 && bossHitPoints > 0)
            {
                if (playerTurn)
                {
                    bossHitPoints = BossDefend(bossArmor, playerDamage, bossHitPoints);
                }
                else if(!playerTurn)
                {
                    playerHitPoints = PlayerDefend(playerArmor, bossDamage, playerHitPoints);
                }
                playerTurn = !playerTurn;
            }
            
            Console.WriteLine("Did we win? " + (playerHitPoints > 0));

            return (playerHitPoints > 0);
        }

        private static int PlayerDefend(int playerArmor, int bossDamage, int playerHitPoints)
        {
            if (playerArmor >= bossDamage)
            {
                playerHitPoints--;
            }
            else if (playerArmor < bossDamage)
            {
                playerHitPoints -= (bossDamage - playerArmor);
            }

            return playerHitPoints;
        }

        private static int BossDefend(int bossArmor, int playerDamage, int bossHitPoints)
        {
            if (bossArmor >= playerDamage)
            {
                bossHitPoints--;
            }
            else if (bossArmor < playerDamage)
            {
                bossHitPoints = bossHitPoints - (playerDamage - bossArmor);
            }

            return bossHitPoints;
        }

        public int CostOptimizer()
        {
            var armorValue = 0;
            var damageValue = 0;
            var goldValue = 0;
            var indexTracker = 0;
            var playerWon = false;
            var ringTwoWorn = true;

            for (int weaponIndex = 0; weaponIndex < 5; weaponIndex++)
            {
                for (int armorIndex = 0; armorIndex < 6; armorIndex++)
                {
                    for (int ringOneIndex = 0; ringOneIndex < 7; ringOneIndex++)
                    {
                        for (int ringTwoIndex = 0; ringTwoIndex < 7; ringTwoIndex++)
                        {
                            //logic to prevent purchasing two of same ring
                            if (ringOneIndex == ringTwoIndex)
                            {
                                ringTwoWorn = false;
                            }

                            armorValue = ComputeArmorValue(armorIndex, ringOneIndex, ringTwoIndex, ringTwoWorn);
                            damageValue = ComputeDamageValue(weaponIndex, ringOneIndex, ringTwoIndex, ringTwoWorn);
                            goldValue = ComputeGoldValue(armorIndex, weaponIndex, ringOneIndex, ringTwoIndex, ringTwoWorn);
                            playerWon = Run(armorValue, damageValue);
                            _roundDataCollection.Add(new RoundData(weaponIndex, armorIndex, ringOneIndex, ringTwoIndex,
                                goldValue, playerWon));
                            
                            Console.WriteLine("Set #" + indexTracker);

                            indexTracker++;
                            
                            armorValue = 0;
                            damageValue = 0;
                            goldValue = 0;
                            ringTwoWorn = true;
                        }
                    }
                }
            }

            var lowestGoldWinner = _roundDataCollection.Where(x => x.matchOutcome).Min(x => x.goldValue);
            var highestGoldWinner = _roundDataCollection.Where(x => x.matchOutcome == false).Max(x => x.goldValue);
            
            Console.WriteLine("Lowest amount of gold to spend: " + lowestGoldWinner);
            Console.WriteLine("Lowest amount of gold to spend: " + highestGoldWinner);
            return 0;
        }

        private void PrintShopInventory()
        {
            foreach (var item in _equipment.shopInventory)
            {
                Console.WriteLine(
                    $"TYPE: {item.Type} NAME: {item.Name} COST: {item.Cost} DAMAGE: {item.Damage} ARMOR: {item.Armor}");
            }
        }

        private int ComputeArmorValue(int armorIndex, int ringOneIndex, int ringTwoIndex, bool ringTwoWorn)
        {
            var armorValue = 0;
            if (armorIndex < _equipment.armor.Count)
            {
                armorValue += _equipment.armor[armorIndex].Armor;
            }
            if (ringOneIndex < _equipment.rings.Count)
            {
                armorValue += _equipment.rings[ringOneIndex].Armor;
            }
            if (ringTwoIndex < _equipment.rings.Count && ringTwoWorn)
            {
                armorValue += _equipment.rings[ringTwoIndex].Armor;
            }

            return armorValue;
        }
        private int ComputeGoldValue(int armorIndex, int weaponIndex, int ringOneIndex, int ringTwoIndex, bool ringTwoWorn)
        {
            var goldValue = 0;
            
            if (armorIndex < _equipment.armor.Count)
            {
                goldValue += _equipment.armor[armorIndex].Cost;
            }
            if (weaponIndex < _equipment.weapons.Count)
            {
                goldValue += _equipment.weapons[weaponIndex].Cost;
            }
            if (ringOneIndex < _equipment.rings.Count)
            {
                goldValue += _equipment.rings[ringOneIndex].Cost;
            }
            if (ringTwoIndex < _equipment.rings.Count && ringTwoWorn)
            {
                goldValue += _equipment.rings[ringTwoIndex].Cost;
            }

            return goldValue;
        }
        private int ComputeDamageValue(int weaponIndex, int ringOneIndex, int ringTwoIndex, bool ringTwoWorn)
        {
            var damageValue = 0;
            if (weaponIndex < _equipment.weapons.Count)
            {
                damageValue += _equipment.weapons[weaponIndex].Damage;
            }
            if (ringOneIndex < _equipment.rings.Count)
            {
                damageValue += _equipment.rings[ringOneIndex].Damage;
            }
            if (ringTwoIndex < _equipment.rings.Count && ringTwoWorn)
            {
                damageValue += _equipment.rings[ringTwoIndex].Damage;
            }

            return damageValue;
        }

        
    }
}
