using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_BasedGame.Models
{
    public class Resource
    {
        public long Gold { get; set; }
        public long Diamond { get; set; }

        public Resource() { }

        public Resource(long gold, long diamond)
        {
            Gold = gold;
            Diamond = diamond;
        }

        public override bool Equals(object? obj)
        {
            return obj is Resource resource &&
                   Gold == resource.Gold &&
                   Diamond == resource.Diamond;
        }
    }
}
