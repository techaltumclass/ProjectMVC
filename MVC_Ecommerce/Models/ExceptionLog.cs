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
    
    public partial class ExceptionLog
    {
        public int LOGID { get; set; }
        public System.DateTime LOGDATETIME { get; set; }
        public string SOURCE { get; set; }
        public string MESSAGE { get; set; }
        public string QUERYSTRING { get; set; }
        public string TARGETSITE { get; set; }
        public string STACKTRACE { get; set; }
        public string SERVERNAME { get; set; }
        public string REQUESTURL { get; set; }
        public string USERAGENT { get; set; }
        public string USERIP { get; set; }
        public Nullable<int> USERID { get; set; }
        public bool Active { get; set; }
    }
}
