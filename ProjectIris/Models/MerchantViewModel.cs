using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectIris.Models
{
    public class MerchantViewModel
    {
        public decimal total { get; set; }
        public int discount { get; set; }
        public decimal subtotal { get; set; }
        public object iriscode { get; set; }
        public string employeeid { get; set; }
    }
}