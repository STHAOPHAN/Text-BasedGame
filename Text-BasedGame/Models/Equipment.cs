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
        [JsonProperty("Level")]
        public int Level { get; set; }

        [JsonProperty("Quality")]
        public string Quality { get; set; }

        [JsonProperty("HP")]
        public int HP { get; set; }

        [JsonProperty("Damage")]
        public int Damage { get; set; }

        [JsonProperty("AttackSpeed")]
        public int AttackSpeed { get; set; }

        [JsonProperty("Armor")]
        public int Armor { get; set; }

        [JsonConstructor]
        public Equipment(string name, string type, string description, string image, int level, string quality, int hP, int damage, int attackSpeed, int armor) : base(name, type, description, image)
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
    }
}
