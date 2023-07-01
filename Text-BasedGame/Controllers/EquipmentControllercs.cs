using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_BasedGame.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Text_BasedGame.Controllers
{
    public class EquipmentControllercs
    {
        List<Equipment> equipmentList = new List<Equipment>();
        public EquipmentControllercs() { }
        public Equipment LoadEquipmentFromFile(string filePath, Enemy enemy)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 4)
                        {
                            string name = parts[0];
                            string type = parts[1];
                            string description = parts[2];
                            string image = parts[3];

                            Equipment equipment = new Equipment(name, type, description, image);
                            equipmentList.Add(equipment);
                        }
                    }
                    Equipment e = GetRandomEquipment(enemy);
                    return e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading equipment from file: " + e.Message);
                throw;
            }
        }
        public Equipment GetRandomEquipment(Enemy enemy)
        {
            Random random = new Random();
            Equipment randomEquipment = equipmentList[random.Next(equipmentList.Count)];

            // Chọn ngẫu nhiên 2 chỉ số để khởi tạo trang bị
            List<string> stats = new List<string> { "HP", "Damage", "AttackSpeed", "Armor" };
            var selectedStats = stats.OrderBy(x => random.Next()).Take(2).ToList();

            List<string> quality = new List<string> { "Common", "Rare", "Elite", "Legendary" };

            // Tạo danh sách trọng số tương ứng với mỗi thành phần
            List<int> weights = new List<int> { 70, 20, 8, 2 };

            // Tính tổng trọng số
            int totalWeight = weights.Sum();

            // Sắp xếp các thành phần theo tỉ lệ trọng số
            var selectedQuality = quality.OrderBy(x => random.Next(0, totalWeight))
                                     .Take(1)
                                     .ToList();
            // Random phẩm chất vật phẩm
            randomEquipment.Quality = selectedQuality[0];
            // Cấp độ theo cấp của địch
            randomEquipment.Level = enemy.level;
            int level = randomEquipment.Level;

            int weight = 0;
            if (randomEquipment.Quality.Equals("Common"))
            {
                weight = level;
            }
            else if (randomEquipment.Quality.Equals("Rare"))
            {
                weight = level * 2;
            }
            else if (randomEquipment.Quality.Equals("Elite"))
            {
                weight = level * 3;
            }
            else if (randomEquipment.Quality.Equals("Legendary"))
            {
                weight = level * 5;
            }

            // Khởi tạo giá trị cho các chỉ số
            foreach (string stat in selectedStats)
            {
                int value;
                switch (stat)
                {
                    case "HP":
                        value = random.Next(50, 100 + 1);
                        randomEquipment.HP = value + (weight * 10);
                        break;
                    case "Damage":
                        value = random.Next(5, 10 + 1);
                        randomEquipment.Damage = value + weight;
                        break;
                    case "AttackSpeed":
                        value = random.Next(10, 20 + 1);
                        randomEquipment.AttackSpeed = value + (weight * 2);
                        break;
                    case "Armor":
                        value = random.Next(5, 10 + 1);
                        randomEquipment.Armor = value + weight;
                        break;
                }
            }
            return randomEquipment;
        }
    }
}
