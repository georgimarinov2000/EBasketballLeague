using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataStructure
{
    public class Arena:BaseModel
    {
        public int Capacity { get; set; }
        public virtual  Team Team { get; set; }
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        
    }
}
