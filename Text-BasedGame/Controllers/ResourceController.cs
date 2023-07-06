using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_BasedGame.Models;

namespace Text_BasedGame.Controllers
{
    public class ResourceController
    {
        private Resource resource = new Resource();
        public ResourceController() { }

        public Resource DropResourceFormEnemy(Enemy enemy)
        {
            Random random = new Random();
            if (enemy.name.Equals("Boss"))
            {
                int minGoldValue = 10 * enemy.level * 10; // Giá trị vàng tối thiểu
                int maxGoldValue = 50 * enemy.level * 10; // Giá trị vàng tối đa

                // Tạo một số ngẫu nhiên trong khoảng từ cận dưới đến cận trên
                int goldValue = random.Next(minGoldValue, maxGoldValue + 1);

                resource.Gold = goldValue;

                int minDiamondValue = 10 + enemy.level * 5; // Giá trị kim cương tối thiểu
                int maxDiamondValue = 20 + enemy.level * 5; // Giá trị kim cương tối đa

                // Tạo một số ngẫu nhiên trong khoảng từ cận dưới đến cận trên
                int diamondValue = random.Next(minDiamondValue, maxDiamondValue + 1);

                resource.Diamond = diamondValue;
            }
            else
            {
                int minGoldValue = 10 * enemy.level; // Giá trị vàng tối thiểu
                int maxGoldValue = 50 * enemy.level; // Giá trị vàng tối đa

                // Tạo một số ngẫu nhiên trong khoảng từ cận dưới đến cận trên
                int goldValue = random.Next(minGoldValue, maxGoldValue + 1);

                resource.Gold = goldValue;

                // Tạo một số ngẫu nhiên trong khoảng từ 0 đến 1
                double randomNumber = random.NextDouble();

                // Kiểm tra nếu số ngẫu nhiên nhỏ hơn 50%, tạo một đối tượng Diamond
                if (randomNumber < 0.5)
                {
                    int minDiamondValue = 10 + enemy.level; // Giá trị kim cương tối thiểu
                    int maxDiamondValue = 20 + enemy.level; // Giá trị kim cương tối đa

                    // Tạo một số ngẫu nhiên trong khoảng từ cận dưới đến cận trên
                    int diamondValue = random.Next(minDiamondValue, maxDiamondValue + 1);

                    resource.Diamond = diamondValue;
                } else
                {
                    resource.Diamond = 0;
                }
            }
            return resource;
        }
    }
}
