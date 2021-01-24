using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Player:BaseModel
    {
        public int Age { get; set; }
        public string Position { get; set; }
        public virtual List<PlayerBrand> PlayerBrands { get; set; }
        public virtual Team Team { get; set; }
    }
}
