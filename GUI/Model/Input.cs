//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUI.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Input
    {
        public int id { get; set; }
        public int idCategory { get; set; }
        public int idProduct { get; set; }
        public System.DateTime Date_Input { get; set; }
        public int count { get; set; }
        public double priceInput { get; set; }
    
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Product Product { get; set; }
    }
}