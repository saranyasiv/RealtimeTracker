using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOdals
{
    public class Login
    {
        [Key]
        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
