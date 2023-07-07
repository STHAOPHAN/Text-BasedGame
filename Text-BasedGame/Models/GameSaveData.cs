using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Text_BasedGame.Models
{
    public class GameSaveData
    {
        public List<Player> Players { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Item> Items { get; set; }

        public List<Equipment> Equipments { get; set; }

        public Resource Resource { get; set; }

        public GameSaveData(List<Player> players, List<Enemy> enemies, List<Item> items, List<Equipment> equipments, Resource resource)
        {
            Players = players;
            Enemies = enemies;
            Items = items;
            Equipments = equipments;
            Resource = resource;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static GameSaveData FromJson(string json)

        {
            return JsonConvert.DeserializeObject<GameSaveData>(json);
        }

        public GameSaveData()
        {
        }
    }
}
