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

        public void IncreaseHealth(Player player)
        {
            if (player.statPoints > 0)
            {
                player.curHealth += 10;
                player.maxHealth += 10; // Tăng 10 HP
                player.statPoints--;
            }
        }

        public void IncreaseDamage(Player player)
        {
            if (player.statPoints > 0)
            {
                player.damage += 1; // Tăng 1 damage
                player.statPoints--;
            }
        }

        public void IncreaseAttackSpeed(Player player)
        {
            if (player.statPoints > 0)
            {
                player.attackSpeed += 0.1f; // Tăng 1 damage
                player.statPoints--;
            }
        }

        public void IncreaseArmor(Player player)
        {
            if (player.statPoints > 0)
            {
                player.armor += 1; // Tăng 1 damage
                player.statPoints--;
            }
        }

        public void ResetStatPoint(Player player)
        {
            player.statPoints = player.level * 5;
            player.level = 1;
            player.curHealth = 100;
            player.maxHealth = 100;
            player.damage = 10;
            player.attackSpeed = 5;
            player.armor = 5;
        }
    }
}
