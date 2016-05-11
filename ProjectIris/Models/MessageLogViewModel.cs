using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIris.Models
{
    public class MessageLogViewModel
    {
        public int id { get; set; }
        public DateTime datecreated { get; set; }
        public string message { get; set; }
        public string info { get; set; }
        public string type { get; set; }
    }
}