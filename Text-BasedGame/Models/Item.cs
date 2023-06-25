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
        //public string Level { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Item(string name, string type, string description, string image)
        {
            Name = name;
            Type = type;
            Description = description;
            Image = image;
        }


        // Thêm các thuộc tính khác tùy theo yêu cầu của trò chơi

    }
}
