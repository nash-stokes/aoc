using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCProblemSolvers._2015Day21
{
    internal class Engine
    {
        public static bool Run(Player player, Character boss)
        {
            bool playerTurn = false;
           
            while (player._hitPoints > 0 && boss._hitPoints > 0)
            {
                if (playerTurn)
                {
                    boss._hitPoints = player.Attack(boss);
                }
                else if(!playerTurn)
                {
                    player._hitPoints = boss.Attack(player);
                }
                playerTurn = !playerTurn;
            }

            return (player._hitPoints > 0);
        }
    }
}
