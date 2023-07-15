using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_BasedGame.Models
{
    public class Equipment : Item
    {
        // Các thuộc tính của lớp Equipment
        public int Level { get; set; }

        public string Quality { get; set; }

        public int HP { get; set; }

        public int Damage { get; set; }

        public int AttackSpeed { get; set; }

        public int Armor { get; set; }

        [JsonConstructor]
        public Equipment(string name, string type, string description, string image, int pricebuy, int pricesell, int level, string quality, int hP, int damage, int attackSpeed, int armor) : base(name, type, description, image, pricebuy, pricesell)
        {
            Level = level;
            Quality = quality;
            HP = hP;
            Damage = damage;
            AttackSpeed = attackSpeed;
            Armor = armor;
        }



        public Equipment(string name, string type, string description, string image) : base(name, type, description, image)
        {
        }

        public Equipment()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Equipment equipment &&
                   base.Equals(obj) &&
                   Name == equipment.Name &&
                   Type == equipment.Type &&
                   Description == equipment.Description &&
                   Image == equipment.Image &&
                   Level == equipment.Level &&
                   Quality == equipment.Quality &&
                   HP == equipment.HP &&
                   Damage == equipment.Damage &&
                   AttackSpeed == equipment.AttackSpeed &&
                   Armor == equipment.Armor;
        }
    }
}
