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
        public Equipment LoadEquipmentFromFile(string filePath)
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
                    Equipment e = GetRandomEquipment();
                    return e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading equipment from file: " + e.Message);
                throw;
            }
        }
        public Equipment GetRandomEquipment()
        {
            Random random = new Random();
            Equipment randomEquipment = equipmentList[random.Next(equipmentList.Count)];

            // Chọn ngẫu nhiên 2 chỉ số để khởi tạo trang bị
            List<string> stats = new List<string> { "HP", "Damage", "AttackSpeed", "Armor" };
            var selectedStats = stats.OrderBy(x => random.Next()).Take(2).ToList();
            // Khởi tạo giá trị cho các chỉ số
            foreach (string stat in selectedStats)
            {
                int value;
                switch (stat)
                {
                    case "HP":
                        value = random.Next(50, 100 + 1);
                        randomEquipment.HP = value;
                        break;
                    case "Damage":
                        value = random.Next(5, 10 + 1);
                        randomEquipment.Damage = value;
                        break;
                    case "AttackSpeed":
                        value = random.Next(10, 20 + 1);
                        randomEquipment.AttackSpeed = value;
                        break;
                    case "Armor":
                        value = random.Next(5, 10 + 1);
                        randomEquipment.Armor = value;
                        break;
                }
            }
            return randomEquipment;
        }
    }
}
