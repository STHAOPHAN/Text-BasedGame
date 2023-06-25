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
        public Item Weapon { get; set; }
        public Item SecondaryWeapon { get; set; }
        public Item Helmet { get; set; }
        public Item ChestArmor { get; set; }
        public Item ArmArmor { get; set; }
        public Item Belt { get; set; }
        public Item Pants { get; set; }
        public Item Boots { get; set; }
        public Item Necklace { get; set; }
        public Item Ring { get; set; }
        public Item Artifact { get; set; }
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
            Item weapon, Item secondaryWeapon, Item helmet, Item chestArmor, Item armArmor, Item belt, Item pants, Item boots, Item necklace, Item ring, Item artifact) : base(name, level, maxHealth, curHealth, damage, armor, attackSpeed)
        {
            this.mana = mana;
            this.ultimate = ultimate;
            this.statPoints = statPoints;
            Weapon = weapon;
            SecondaryWeapon = secondaryWeapon;
            Helmet = helmet;
            ChestArmor = chestArmor;
            ArmArmor = armArmor;
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
