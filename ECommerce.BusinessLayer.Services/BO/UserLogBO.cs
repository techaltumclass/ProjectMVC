using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Services.BO
{
    public class UserLogBO
    {
        public byte LogID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> LoginDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> LogOutDate { get; set; }
    }
}
