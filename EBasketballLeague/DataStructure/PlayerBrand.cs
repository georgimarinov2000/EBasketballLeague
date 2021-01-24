using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class PlayerBrand
    {
        public  int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
