using NUnit.Framework;
using Text_BasedGame.Controllers;
using Text_BasedGame.Models;

namespace Text_BasedGame.Test
{
    [TestFixture]
    public class ResourceControllerTests
    {
        private ResourceController resourceController;
        private Enemy bossEnemy;
        private Enemy normalEnemy;

        [SetUp]
        public void Setup()
        {
            resourceController = new ResourceController();
            bossEnemy = new Enemy();
            bossEnemy.name = "Boss";
            bossEnemy.level = 5;
            normalEnemy = new Enemy();
            normalEnemy.name = "Enemy1";
            normalEnemy.level = 5;
        }

        [Test]
        public void DropResourceFormEnemy_BossEnemy_ReturnsResourceWithGoldAndDiamond()
        {
            // Act
            Resource resource = resourceController.DropResourceFormEnemy(bossEnemy);

            // Assert
            Assert.NotNull(resource);
            Assert.GreaterOrEqual(resource.Gold, bossEnemy.level * 100);
            Assert.LessOrEqual(resource.Gold, bossEnemy.level * 500);
            Assert.GreaterOrEqual(resource.Diamond, 10 + bossEnemy.level * 5);
            Assert.LessOrEqual(resource.Diamond, 20 + bossEnemy.level * 5);
        }

        [Test]
        public void DropResourceFormEnemy_NormalEnemy_ReturnsResourceWithGoldAndPossiblyDiamond()
        {
            // Act
            Resource resource = resourceController.DropResourceFormEnemy(normalEnemy);

            // Assert
            Assert.NotNull(resource);
            Assert.GreaterOrEqual(resource.Gold, normalEnemy.level * 10);
            Assert.LessOrEqual(resource.Gold, normalEnemy.level * 50);

            if (resource.Diamond > 0)
            {
                Assert.GreaterOrEqual(resource.Diamond, 10 + normalEnemy.level);
                Assert.LessOrEqual(resource.Diamond, 20 + normalEnemy.level);
            }
            else
            {
                Assert.That(resource.Diamond, Is.EqualTo(0));
            }
        }
    }
}
