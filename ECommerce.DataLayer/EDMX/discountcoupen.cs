//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECommerce.DataLayer.EDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class discountcoupen
    {
        public int lcoupenid { get; set; }
        public string ccoupenno { get; set; }
        public Nullable<int> lorderid { get; set; }
        public Nullable<double> ldiscount { get; set; }
        public Nullable<System.DateTime> dentrydatetime { get; set; }
        public Nullable<byte> lstatus { get; set; }
        public Nullable<System.DateTime> dfromdate { get; set; }
        public Nullable<System.DateTime> dtodate { get; set; }
        public Nullable<int> lcoupentype { get; set; }
        public Nullable<int> lcoupenproductid { get; set; }
        public string clastipaddress { get; set; }
        public Nullable<byte> lmanualcouponstatus { get; set; }
    }
}