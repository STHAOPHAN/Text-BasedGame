using System;
using Text_BasedGame.Controllers;
using Text_BasedGame.Models;

namespace Text_BasedGame.Test
{
    [TestFixture]
    public class EquipmentControllerTests
    {
        private EquipmentController equipmentController;
        Enemy enemy;
        string filePath;
        Equipment equipment = new Equipment();

        [SetUp]
        public void Setup()
        {
            equipmentController = new EquipmentController();
            enemy = new Enemy("Enemy1", 5, 100, 100, 8, 5, 5);
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.GetFullPath(Path.Combine(currentDirectory, "..\\..\\..\\..\\Text-BasedGame\\Utilities\\Data\\equipment.txt"));
        }

        [Test]
        public void LoadEquipmentFromFile_ValidFilePath_ReturnsEquipment()
        {
            // Act
            Equipment equipment = equipmentController.LoadEquipmentFromFile(filePath, enemy);

            // Assert
            Assert.NotNull(equipment);
            Assert.IsInstanceOf<Equipment>(equipment);
            int count = 0;
            while (count < 10)
            {
                while (!equipment.Quality.Equals("Common"))
                {
                    equipment = equipmentController.LoadEquipmentFromFile(filePath, enemy);
                }
                Assert.IsTrue((equipment.HP != 0 && equipment.Damage == 0 && equipment.AttackSpeed == 0 && equipment.Armor == 0) ||
                    (equipment.HP == 0 && equipment.Damage != 0 && equipment.AttackSpeed == 0 && equipment.Armor == 0) ||
                    (equipment.HP == 0 && equipment.Damage == 0 && equipment.AttackSpeed != 0 && equipment.Armor == 0) ||
                    (equipment.HP == 0 && equipment.Damage == 0 && equipment.AttackSpeed == 0 && equipment.Armor != 0));
                count++;
            }

            count = 0;
            while (count < 20)
            {
                while (!equipment.Quality.Equals("Rare"))
                {
                    equipment = equipmentController.LoadEquipmentFromFile(filePath, enemy);
                }
                Assert.IsTrue((equipment.HP != 0 && equipment.Damage != 0 && equipment.AttackSpeed == 0 && equipment.Armor == 0) ||
                    (equipment.HP != 0 && equipment.Damage == 0 && equipment.AttackSpeed != 0 && equipment.Armor == 0) ||
                    (equipment.HP != 0 && equipment.Damage == 0 && equipment.AttackSpeed == 0 && equipment.Armor != 0) ||
                    (equipment.HP == 0 && equipment.Damage != 0 && equipment.AttackSpeed != 0 && equipment.Armor == 0) ||
                    (equipment.HP == 0 && equipment.Damage != 0 && equipment.AttackSpeed == 0 && equipment.Armor != 0) ||
                    (equipment.HP == 0 && equipment.Damage == 0 && equipment.AttackSpeed != 0 && equipment.Armor != 0) ||
                    (equipment.HP != 0 && equipment.Damage == 0 && equipment.AttackSpeed == 0 && equipment.Armor != 0));
                count++;
            }

            count = 0;
            while (count < 10)
            {
                while (!equipment.Quality.Equals("Elite"))
                {
                    equipment = equipmentController.LoadEquipmentFromFile(filePath, enemy);
                }
                Assert.IsTrue((equipment.HP != 0 && equipment.Damage != 0 && equipment.AttackSpeed != 0 && equipment.Armor == 0) ||
                    (equipment.HP == 0 && equipment.Damage != 0 && equipment.AttackSpeed != 0 && equipment.Armor != 0) ||
                    (equipment.HP != 0 && equipment.Damage != 0 && equipment.AttackSpeed == 0 && equipment.Armor != 0) ||
                    (equipment.HP != 0 && equipment.Damage == 0 && equipment.AttackSpeed != 0 && equipment.Armor != 0));
                count++;
            }
            while (!equipment.Quality.Equals("Legendary"))
            {
                equipment = equipmentController.LoadEquipmentFromFile(filePath, enemy);
            }
            Assert.IsTrue(equipment.HP != 0 && equipment.Damage != 0 && equipment.AttackSpeed != 0 && equipment.Armor != 0);
        }

        [Test]
        public void LoadEquipmentFromFile_InvalidFilePath_ThrowsException()
        {
            // Arrange
            string filePath = "invalid_file_path";

            // Act & Assert
            Assert.Throws<System.IO.FileNotFoundException>(() => equipmentController.LoadEquipmentFromFile(filePath, enemy));
        }
    }
}