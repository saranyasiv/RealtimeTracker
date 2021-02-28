using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOdals
{
    public class Locationinfo
    {
        [Key]
        public long locationID { get; set; }
       
        public long ID { get; set; }
        [ForeignKey("ID")]
        public virtual Login Login { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }

    }
}
