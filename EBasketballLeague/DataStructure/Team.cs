using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataStructure
{
    public class Team:BaseModel
    {
        public int Championships { get; set; }
        [ForeignKey("ArenaId")]
        public int ArenaId { get; set; }
        public virtual Arena Arena { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}
