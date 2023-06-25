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
        public int statPoints { get; set; }
        public Equipment Weapon { get; set; }
        public Equipment SecondaryWeapon { get; set; }
        public Equipment Helmet { get; set; }
        public Equipment ChestArmor { get; set; }
        public Equipment Glove { get; set; }
        public Equipment Belt { get; set; }
        public Equipment Pants { get; set; }
        public Equipment Boots { get; set; }
        public Equipment Necklace { get; set; }
        public Equipment Ring { get; set; }
        public Equipment Artifact { get; set; }
        public Player() { }

        public Player(string name, int level, float maxHealth, float curHealth, int damage, int armor, float attackSpeed, int mana, bool ultimate) : base(name, level, maxHealth, curHealth, damage, armor, attackSpeed)
        {
            this.mana = mana;
            this.ultimate = ultimate;
        }
        public Player(string name, int level, float maxHealth, float curHealth, int damage, int armor, float attackSpeed, int mana, int statPoints) : base(name, level, maxHealth, curHealth, damage, armor, attackSpeed)
        {
            this.mana = mana;

            //Cập nhật số điểm chỉ số ban đầu
            UpdateStatPoints();
        }

        public Player(string name, int level, float maxHealth, float curHealth, int damage, int armor, float attackSpeed, int mana, bool ultimate, int statPoints,
            Equipment weapon, Equipment secondaryWeapon, Equipment helmet, Equipment chestArmor, Equipment glove, Equipment belt, Equipment pants, Equipment boots, Equipment necklace, Equipment ring, Equipment artifact) : base(name, level, maxHealth, curHealth, damage, armor, attackSpeed)
        {
            this.mana = mana;
            this.ultimate = ultimate;
            this.statPoints = statPoints;
            Weapon = weapon;
            SecondaryWeapon = secondaryWeapon;
            Helmet = helmet;
            ChestArmor = chestArmor;
            Glove = glove;
            Belt = belt;
            Pants = pants;
            Boots = boots;
            Necklace = necklace;
            Ring = ring;
            Artifact = artifact;
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

        public void UpdateStatPoints()
        {
            // Scale số điểm chỉ số dựa trên cấp độ
            statPoints = level * 5;
        }
    }
}
