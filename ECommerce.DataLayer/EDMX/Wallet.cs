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
    
    public partial class Wallet
    {
        public int WalletId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public int UserId { get; set; }
        public Nullable<decimal> DepositAmount { get; set; }
        public Nullable<decimal> WithdrawalAmount { get; set; }
        public Nullable<int> DepositByAdminId { get; set; }
        public Nullable<int> WithdrawalByUserId { get; set; }
        public string Statusfor { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
    
        public virtual order1 order1 { get; set; }
    }
}
