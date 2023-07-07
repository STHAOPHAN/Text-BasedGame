using NUnit.Framework;
using System.IO;
using Text_BasedGame.Controllers;
using Text_BasedGame.Models;

namespace Text_BasedGame.Test
{
    [TestFixture]
    public class GameSaveDataControllerTests
    {
        private GameSaveDataController gameSaveDataController;
        private string saveFilePath;
        private List<Player> playerList;
        private List<Enemy> enemyList;
        private List<Item> itemList;
        private List<Equipment> equipList;
        private Resource resources;
        private GameSaveData gameSaveData;
        private StatsPoint statsPoint = new StatsPoint(0, 0, 0, 0);

        [SetUp]
        public void Setup()
        {
            gameSaveDataController = new GameSaveDataController();
            saveFilePath = "..\\..\\..\\..\\Text-BasedGame.Test\\save1.json";
            playerList = new List<Player>
            {
                new Player("Player1", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint),//Name, Max Health, Current Health, Damage, Armor, Attack Speed, Mana, statspoint
                new Player("Player2", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint),
                new Player("Player3", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint),
                new Player("Player4", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint),
                new Player("Player5", 1, 100, 100, 20, 10, 4, 0, 5, statsPoint)
            };
            enemyList = new List<Enemy>
            {
                new Enemy("Enemy1", 5, 100, 100, 8, 5, 5),//Name, Max Health, Current Health, Damage, Armor, Attack Speed
                new Enemy("Enemy2", 5, 100, 100, 8, 5, 5),
                new Enemy("Enemy3", 5, 100, 100, 8, 5, 5),
                new Enemy("Enemy4", 5, 100, 100, 8, 5, 5),
                new Enemy("Enemy5", 5, 100, 100, 8, 5, 5)
            };
            itemList = new List<Item>();
            equipList = new List<Equipment>
            {
                new Equipment("Belt", "Belt", "", "", 1, "Common", 0, 0, 0, 10)
            };
            resources = new Resource(1000, 200);

            gameSaveData = new GameSaveData();
            gameSaveData.Players = playerList;
            gameSaveData.Enemies = enemyList;
            gameSaveData.Items = itemList;
            gameSaveData.Equipments = equipList;
            gameSaveData.Resource = resources;


        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(saveFilePath))
            {
                File.Delete(saveFilePath);
            }
        }

        [Test]
        public void SaveGame_ValidSaveData_ReturnsTrueAndSavesDataToFile()
        {
            // Act
            bool result = gameSaveDataController.SaveGame(gameSaveData, saveFilePath);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(saveFilePath));
        }

        [Test]
        public void LoadGame_ExistingSaveFile_ReturnsSaveData()
        {

            // Create a save file
            File.WriteAllText(saveFilePath, gameSaveData.ToJson());

            // Act
            GameSaveData loadedData = gameSaveDataController.LoadGame(saveFilePath);

            // Assert
            Assert.NotNull(loadedData);
            Assert.That(loadedData.Players, Is.EqualTo(gameSaveData.Players));
            Assert.That(loadedData.Enemies, Is.EqualTo(gameSaveData.Enemies));
            Assert.That(loadedData.Items, Is.EqualTo(gameSaveData.Items));
            Assert.That(loadedData.Equipments, Is.EqualTo(gameSaveData.Equipments));
            Assert.That(loadedData.Resource, Is.EqualTo(gameSaveData.Resource));
        }

        [Test]
        public void LoadGame_NonExistingSaveFile_ReturnsNull()
        {
            string saveFilePath = "..\\..\\..\\..\\Text-BasedGame.Test\\save69.json";
            // Act
            GameSaveData loadedData = gameSaveDataController.LoadGame(saveFilePath);

            // Assert
            Assert.Null(loadedData);
        }
    }
}

