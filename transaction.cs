//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace emarket
{
    using System;
    using System.Collections.Generic;
    
    public partial class transaction
    {
        public long transactionID { get; set; }
        public long userID { get; set; }
        public long orderID { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public Nullable<System.DateTime> updatedAt { get; set; }
        public string paymentGatewayID { get; set; }
    
        public virtual order order { get; set; }
        public virtual user user { get; set; }
    }
}