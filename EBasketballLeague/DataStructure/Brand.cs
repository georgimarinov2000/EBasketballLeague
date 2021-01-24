using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Brand:BaseModel
    {
        public virtual List<PlayerBrand> PlayerBrands { get; set; }
    }
}
