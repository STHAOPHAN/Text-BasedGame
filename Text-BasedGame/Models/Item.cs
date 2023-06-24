using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_BasedGame.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Item(string name, string type)
        {
            Name = name;
            Type = type;
        }
        // Thêm các thuộc tính khác tùy theo yêu cầu của trò chơi

    }
}
