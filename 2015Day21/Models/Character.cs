using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoCProblemSolvers._2015Day21
{
    internal class Character
    {
        public string _name { get; set; }
        public int _hitPoints { get; set; }
        public int _damage { get; set; }
        public int _armor { get; set; }
        public Item[] _equipment { get; set; }

        public Character(string name, int hitPoints, int damage, int armor)
        {
            _name = name;
            _hitPoints = hitPoints;
            _damage = damage;
            _armor = armor;
        }

        public int Attack(Character enemy)
        {
            if(enemy._armor >= this._damage)
            {
                enemy._hitPoints--;
            }
            else if (enemy._armor < this._damage)
            {
                enemy._hitPoints = enemy._hitPoints - (this._damage- enemy._armor); 
            }
            return enemy._hitPoints;
        }
    }
}
