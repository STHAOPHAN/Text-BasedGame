﻿using System;
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

            List<string> quality = new List<string> { "Common", "Rare", "Elite", "Legendary" };
            List<int> weights;
            if (enemy.name.Equals("Boss")) weights = new List<int> { 50, 25, 15, 10 };
            else weights = new List<int> { 70, 20, 8, 2 };

            // Tính tổng trọng số
            int totalWeight = weights.Sum();

            // Chọn ngẫu nhiên một số từ 0 đến tổng trọng số
            int randomValue = random.Next(0, totalWeight);

            // Xác định phẩm chất tương ứng với số ngẫu nhiên
            int cumulativeWeight = 0;
            string selectedQuality = "";
            for (int i = 0; i < quality.Count; i++)
            {
                cumulativeWeight += weights[i];
                if (randomValue < cumulativeWeight)
                {
                    selectedQuality = quality[i];
                    break;
                }
            }
            var selectedStats = new List<string>();
            if (selectedQuality.Equals("Common"))
            {
                List<string> stats = new List<string> { "HP", "Damage", "AttackSpeed", "Armor" };
                selectedStats = stats.OrderBy(x => random.Next()).Take(1).ToList();
            }
            else if (selectedQuality.Equals("Rare"))
            {
                List<string> stats = new List<string> { "HP", "Damage", "AttackSpeed", "Armor" };
                selectedStats = stats.OrderBy(x => random.Next()).Take(2).ToList();
            }
            else if (selectedQuality.Equals("Elite"))
            {
                List<string> stats = new List<string> { "HP", "Damage", "AttackSpeed", "Armor" };
                selectedStats = stats.OrderBy(x => random.Next()).Take(3).ToList();
            }
            else if (selectedQuality.Equals("Legendary"))
            {
                List<string> stats = new List<string> { "HP", "Damage", "AttackSpeed", "Armor" };
                selectedStats = stats.OrderBy(x => random.Next()).Take(4).ToList();
            }

            randomEquipment.Quality = selectedQuality;
            randomEquipment.Level = enemy.level;

            int weight = 0;
            if (randomEquipment.Quality.Equals("Common"))
            {
                weight = enemy.level;
            }
            else if (randomEquipment.Quality.Equals("Rare"))
            {
                weight = enemy.level * 2;
            }
            else if (randomEquipment.Quality.Equals("Elite"))
            {
                weight = enemy.level * 3;
            }
            else if (randomEquipment.Quality.Equals("Legendary"))
            {
                weight = enemy.level * 5;
            }

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
