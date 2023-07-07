using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_BasedGame.Models
{
    public class StatsPoint
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
        public int Armor {  get; set; }

        public StatsPoint(int hP, int damage, int attackSpeed, int armor)
        {
            HP = hP;
            Damage = damage;
            AttackSpeed = attackSpeed;
            Armor = armor;
        }

        public StatsPoint()
        {
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            StatsPoint other = (StatsPoint)obj;
            return HP == other.HP && Damage == other.Damage && AttackSpeed == other.AttackSpeed && Armor == other.Armor;
        }
    }
}
