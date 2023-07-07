using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_BasedGame.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Text_BasedGame.Controllers
{
    public class PlayerController
    {
        private List<Player> players;

        public PlayerController(List<Player> players)
        {
            this.players = players;
        }

        public PlayerController()
        {
        }

        public void IncreasePlayerStats(Player player, Equipment item)
        {
            if (item is Equipment)
            {
                Equipment equipment = (Equipment)item;

                player.curHealth += equipment.HP;
                player.maxHealth += equipment.HP;
                player.damage += equipment.Damage;
                float attackspeed = equipment.AttackSpeed;
                player.attackSpeed -= (attackspeed / 100);
                player.armor += equipment.Armor;


                // Cập nhật các chỉ số khác tùy thuộc vào trang bị
            }
        }

        public void DecreasePlayerStats(Player player, Item item)
        {
            if (item is Equipment)
            {
                Equipment equipment = (Equipment)item;

                player.curHealth -= equipment.HP;
                player.maxHealth -= equipment.HP;
                player.damage -= equipment.Damage;
                float attackspeed = equipment.AttackSpeed;
                player.attackSpeed += (attackspeed / 100);
                player.armor -= equipment.Armor;


                // Cập nhật các chỉ số khác tùy thuộc vào trang bị
            }
        }

        public void IncreaseHealth(Player player)
        {
            if (player.statPoints > 0)
            {
                player.curHealth += 10;
                player.maxHealth += 10; // Tăng 10 HP
                player.statPoints--; // mất 1 điểm chỉ số
                player.distributedPoints.HP++;
            }
        }

        public void IncreaseDamage(Player player)
        {
            if (player.statPoints > 0)
            {
                player.damage += 1; // Tăng 1 damage
                player.statPoints--;
                player.distributedPoints.Damage++;
            }
        }

        public void IncreaseAttackSpeed(Player player)
        {
            if (player.statPoints > 0)
            {
                player.attackSpeed -= 0.1f; // Giảm 0.1s
                player.statPoints--;
                player.distributedPoints.AttackSpeed++;
            }
        }

        public void IncreaseArmor(Player player)
        {
            if (player.statPoints > 0)
            {
                player.armor += 1; // Tăng 1 giáp
                player.statPoints--;
                player.distributedPoints.Armor++;
            }
        }

        public void LevelUp(Player player)
        {
            player.level += 1; // Tăng 1 cấp
            player.statPoints += 5; // Cộng 5 điểm chỉ số
        }

        public void ResetStatPoint(Player player)
        {
            player.statPoints = player.level * 5;
            player.level = 1;
            player.curHealth -= 10 * player.distributedPoints.HP;
            player.maxHealth -= 10 * player.distributedPoints.HP;
            player.distributedPoints.HP = 0;
            player.damage -= 1 * player.distributedPoints.Damage;
            player.distributedPoints.Damage = 0;
            player.attackSpeed += 0.1f * (float)player.distributedPoints.AttackSpeed;
            player.distributedPoints.AttackSpeed = 0;
            player.armor -= 1 * player.distributedPoints.Armor;
            player.distributedPoints.Armor = 0;
        }
    }
}
