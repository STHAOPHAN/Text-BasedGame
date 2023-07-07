using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_BasedGame.Models
{
    public class Enemy : Creature
    {
        public Enemy() { }

        public Enemy(string name, int level, float maxHealth, float curHealth, int damage, int armor, float attackSpeed) : base(name, level, maxHealth, curHealth, damage, armor, attackSpeed)
        {
        }

        public override void Attack(Creature target)
        {
            base.Attack(target);
            if (target.armor > damage)
            {
                target.curHealth -= 1;
            }
            else 
            { 
                target.curHealth -= (damage - target.armor);
            }
            // Các logic tấn công đặc biệt cho Player
            // ...
        }

        public override bool Equals(object? obj)
        {
            return obj is Enemy enemy &&
                   name == enemy.name &&
                   level == enemy.level &&
                   maxHealth == enemy.maxHealth &&
                   curHealth == enemy.curHealth &&
                   damage == enemy.damage &&
                   armor == enemy.armor &&
                   attackSpeed == enemy.attackSpeed;
        }
    }
}
