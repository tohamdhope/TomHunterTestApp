using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    internal class Users
    {
        [Key]
        public int UserID { get; set; } 
        public string UserLogin { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "|    User: " + UserID + " " + UserLogin + "  " + Password + "  |";
        }
    }
}
