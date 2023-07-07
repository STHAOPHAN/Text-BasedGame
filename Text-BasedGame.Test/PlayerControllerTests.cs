using NUnit.Framework;
using System.Collections.Generic;
using Text_BasedGame.Controllers;
using Text_BasedGame.Models;

namespace Text_BasedGame.Test
{
    [TestFixture]
    public class PlayerControllerTests
    {
        private PlayerController playerController;
        private Player player;
        private Equipment equipment;
        private StatsPoint statsPoint = new StatsPoint(0, 0, 0, 0);

        [SetUp]
        public void Setup()
        {
            playerController = new PlayerController();
            player = new Player("Player1", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint);
            equipment = new Equipment("Sword", "Weapon", "A powerful sword", "sword.png", 1, "Legendary", 100, 10, 20, 5);
        }

        [Test]
        public void IncreasePlayerStats_ShouldIncreasePlayerStats()
        {
            // Act
            playerController.IncreasePlayerStats(player, equipment);

            // Assert
            Assert.That(player.curHealth, Is.EqualTo(100 + equipment.HP));
            Assert.That(player.maxHealth, Is.EqualTo(100 + equipment.HP));
            Assert.That(player.damage, Is.EqualTo(20 + equipment.Damage));
            Assert.That(player.attackSpeed, Is.EqualTo(4f - ((float)equipment.AttackSpeed / 100)));
            Assert.That(player.armor, Is.EqualTo(10 + equipment.Armor));
        }

        [Test]
        public void DecreasePlayerStats_ShouldDecreasePlayerStats()
        {
            // Act
            playerController.IncreasePlayerStats(player, equipment);
            playerController.DecreasePlayerStats(player, equipment);

            // Assert
            Assert.That(player.curHealth, Is.EqualTo(100));
            Assert.That(player.maxHealth, Is.EqualTo(100));
            Assert.That(player.damage, Is.EqualTo(20));
            Assert.That(player.attackSpeed, Is.EqualTo(4));
            Assert.That(player.armor, Is.EqualTo(10));
        }

        [Test]
        public void IncreaseStats_ShouldIncreaseStatsAndDecreaseStatPoints()
        {
            // Act
            playerController.IncreaseHealth(player);

            // Assert
            Assert.That(player.curHealth, Is.EqualTo(110));
            Assert.That(player.maxHealth, Is.EqualTo(110));
            Assert.That(player.statPoints, Is.EqualTo(4));

            // Act
            playerController.IncreaseDamage(player);

            // Assert
            Assert.That(player.damage, Is.EqualTo(21));
            Assert.That(player.statPoints, Is.EqualTo(3));

            // Act
            playerController.IncreaseAttackSpeed(player);

            // Assert
            Assert.That(player.attackSpeed, Is.EqualTo(3.9f));
            Assert.That(player.statPoints, Is.EqualTo(2));

            // Act
            playerController.IncreaseArmor(player);

            // Assert
            Assert.That(player.armor, Is.EqualTo(11));
            Assert.That(player.statPoints, Is.EqualTo(1));

        }

        [Test]
        public void LevelUp_ShouldIncreaseLevelAndStatPoints()
        {
            // Arrange
            player.level = 5;
            player.statPoints = 25;

            // Act
            playerController.LevelUp(player);

            // Assert
            Assert.That(player.level, Is.EqualTo(6));
            Assert.That(player.statPoints, Is.EqualTo(30));
        }

        [Test]
        public void ResetStatPoint_ShouldResetStatPointAndPlayerStats()
        {
            // Arrange
            player.statPoints = 0;
            player.level = 4;
            player.curHealth = 150;
            player.maxHealth = 150;
            player.damage = 15;
            player.attackSpeed = 3.5f;
            player.armor = 15;
            player.distributedPoints = new StatsPoint(5, 5, 5, 5);
            statsPoint = new StatsPoint(0, 0, 0, 0);
            // Act
            playerController.ResetStatPoint(player);

            // Assert
            Assert.That(player.statPoints, Is.EqualTo(20));
            Assert.That(player.level, Is.EqualTo(1));
            Assert.That(player.curHealth, Is.EqualTo(100));
            Assert.That(player.maxHealth, Is.EqualTo(100));
            Assert.That(player.damage, Is.EqualTo(10));
            Assert.That(player.attackSpeed, Is.EqualTo(4f));
            Assert.That(player.armor, Is.EqualTo(10));
            Assert.That(player.distributedPoints, Is.EqualTo(statsPoint));
        }
    }
}