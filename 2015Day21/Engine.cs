namespace AoCProblemSolvers._2015Day21
{
    class Engine
    {
        private Character _boss;
        private Equipment _equipment;
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
            for (int i = 1; i < 6; i++)
            {
                var neededArmor = 0;
                var equipmentArmor = neededArmor;
                var equipmentDamage = _equipment.shopInventory[i].Damage;
                var output = Run(equipmentArmor, equipmentDamage);
                while (output != true)
                {
                    neededArmor++;
                    equipmentArmor = neededArmor;
                    output = Run(equipmentArmor, equipmentDamage);
                }
                Console.WriteLine("Needed armor: " + neededArmor);
            }
            return 0;
        }
    }
}
