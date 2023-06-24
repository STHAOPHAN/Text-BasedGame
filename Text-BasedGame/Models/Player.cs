using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_BasedGame.Models
{
    public class Player : Creature
    {
        public int mana { get; set; }
        public bool ultimate { get; set; }
        public Player() { }

        public Player(string name, float maxHealth, float curHealth, int damage, int armor, float attackSpeed, int mana, bool ultimate) : base(name, maxHealth, curHealth, damage, armor, attackSpeed)
        {
            this.mana = mana;
            this.ultimate = ultimate;
        }
        public Player(string name, float maxHealth, float curHealth, int damage, int armor, float attackSpeed, int mana) : base(name, maxHealth, curHealth, damage, armor, attackSpeed)
        {
            this.mana = mana;
        }
        // Phương thức override từ lớp cha Creature
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
        // Phương thức riêng của Player
        public void UseUltimate()
        {
            if (mana >= 100)
            {
                ultimate = true;
                // Các logic sử dụng Ultimate
                // ...
                mana -= 100;
            }
            else
            {
                ultimate = false;
                // Hiển thị thông báo hoặc xử lý khi không đủ mana
                // ...
            }
        }
    }
}
