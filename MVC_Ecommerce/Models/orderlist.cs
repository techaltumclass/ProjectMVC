//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderlist
    {
        public int lproductlistid { get; set; }
        public Nullable<int> lproductid { get; set; }
        public Nullable<int> lorderid { get; set; }
        public Nullable<int> lquantity { get; set; }
        public Nullable<double> lprice { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<bool> CancelByUserStatus { get; set; }
        public Nullable<System.DateTime> CByUserDate { get; set; }
        public Nullable<bool> CancelByAdminStatus { get; set; }
        public Nullable<System.DateTime> CByAdminDate { get; set; }
        public string Comment { get; set; }
        public string CancelRegion { get; set; }
    }
}
