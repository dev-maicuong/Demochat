using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demochat.Models
{
    public class mess
    {
        public int id_mess { get; set; }
        public string mess_content { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<int> id_userSend { get; set; }
    }
}