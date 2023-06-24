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

        public Enemy(string name, float maxHealth, float curHealth, int damage, int armor, float attackSpeed) : base(name, maxHealth, curHealth, damage, armor, attackSpeed)
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
    }
}
