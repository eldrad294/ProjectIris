//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectIris.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        public int id { get; set; }
        public int clientid { get; set; }
        public string accountnumber { get; set; }
        public string accounttype { get; set; }
        public int bankid { get; set; }
        public string iban { get; set; }
        public string pin { get; set; }
        public decimal balance { get; set; }
    
        public virtual bank bank { get; set; }
        public virtual client client { get; set; }
    }
}