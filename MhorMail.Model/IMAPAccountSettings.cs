using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MhorMail.Model
{
    public class IMAPAccountSettings
    {
       public ServerConfiguration ServerDetails { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
