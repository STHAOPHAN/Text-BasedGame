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

        public GameSaveData(List<Player> players, List<Enemy> enemies, List<Item> items)
        {
            Players = players;
            Enemies = enemies;
            Items = items;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static GameSaveData FromJson(string json)

        {
            return JsonConvert.DeserializeObject<GameSaveData>(json);
        }
    }
}
