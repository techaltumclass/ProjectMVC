using Ecommerce.BusinessLayer.Services.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Services.BO
{
    public class RoleMasterBO
    {
        public byte RoleID { get; set; }
        public string RollName { get; set; }
        public string RollType { get; set; }
        public string RollDescription { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }

        public virtual UserMasterBO UserMaster { get; set; }
        public virtual ICollection<UserRoleBO> UserRoles { get; set; }
    }
}
