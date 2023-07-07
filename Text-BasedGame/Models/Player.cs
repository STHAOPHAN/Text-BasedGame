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
        public StatsPoint distributedPoints { get; set; }
        public Equipment Weapon { get; set; }
        public Equipment SecondaryWeapon { get; set; }
        public Equipment Helmet { get; set; }
        public Equipment ChestArmor { get; set; }
        public Equipment ArmArmor { get; set; }
        public Equipment Glove { get; set; }
        public Equipment Belt { get; set; }
        public Equipment Pants { get; set; }
        public Equipment Boots { get; set; }
        public Equipment Necklace { get; set; }
        public Equipment Ring { get; set; }
        public Equipment Bracelet { get; set; }
        public Equipment Artifact { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Player() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Player(string name, int level, float maxHealth, float curHealth, int damage, int armor, float attackSpeed, int mana, bool ultimate) : base(name, level, maxHealth, curHealth, damage, armor, attackSpeed)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.mana = mana;
            this.ultimate = ultimate;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Player(string name, int level, float maxHealth, float curHealth, int damage, int armor, float attackSpeed, int mana, int statpoints, StatsPoint distributedPoints) : base(name, level, maxHealth, curHealth, damage, armor, attackSpeed)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.mana = mana;
            this.statPoints = statpoints;
            this.distributedPoints = distributedPoints;

            //Cập nhật số điểm chỉ số ban đầu
            UpdateStatPoints();
        }

        public Player(string name, int level, float maxHealth, float curHealth, int damage, int armor, float attackSpeed, int mana, bool ultimate, int statPoints, StatsPoint distributedPoints,
            Equipment weapon, Equipment secondaryWeapon, Equipment helmet, Equipment chestArmor, Equipment armArmor, Equipment glove, Equipment belt, Equipment pants, Equipment boots, Equipment necklace, Equipment ring, Equipment bracelet, Equipment artifact) : base(name, level, maxHealth, curHealth, damage, armor, attackSpeed)
        {
            this.mana = mana;
            this.ultimate = ultimate;
            this.statPoints = statPoints;
            this.distributedPoints = distributedPoints;
            Weapon = weapon;
            SecondaryWeapon = secondaryWeapon;
            Helmet = helmet;
            ChestArmor = chestArmor;
            ArmArmor = armArmor;
            Glove = glove;
            Belt = belt;
            Pants = pants;
            Boots = boots;
            Necklace = necklace;
            Ring = ring;
            Bracelet = bracelet;
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

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   name == player.name &&
                   level == player.level &&
                   maxHealth == player.maxHealth &&
                   curHealth == player.curHealth &&
                   damage == player.damage &&
                   armor == player.armor &&
                   attackSpeed == player.attackSpeed &&
                   mana == player.mana &&
                   ultimate == player.ultimate &&
                   statPoints == player.statPoints &&
                   EqualityComparer<StatsPoint>.Default.Equals(distributedPoints, player.distributedPoints) &&
                   EqualityComparer<Equipment>.Default.Equals(Weapon, player.Weapon) &&
                   EqualityComparer<Equipment>.Default.Equals(SecondaryWeapon, player.SecondaryWeapon) &&
                   EqualityComparer<Equipment>.Default.Equals(Helmet, player.Helmet) &&
                   EqualityComparer<Equipment>.Default.Equals(ChestArmor, player.ChestArmor) &&
                   EqualityComparer<Equipment>.Default.Equals(ArmArmor, player.ArmArmor) &&
                   EqualityComparer<Equipment>.Default.Equals(Glove, player.Glove) &&
                   EqualityComparer<Equipment>.Default.Equals(Belt, player.Belt) &&
                   EqualityComparer<Equipment>.Default.Equals(Pants, player.Pants) &&
                   EqualityComparer<Equipment>.Default.Equals(Boots, player.Boots) &&
                   EqualityComparer<Equipment>.Default.Equals(Necklace, player.Necklace) &&
                   EqualityComparer<Equipment>.Default.Equals(Ring, player.Ring) &&
                   EqualityComparer<Equipment>.Default.Equals(Bracelet, player.Bracelet) &&
                   EqualityComparer<Equipment>.Default.Equals(Artifact, player.Artifact);
        }
    }
}
