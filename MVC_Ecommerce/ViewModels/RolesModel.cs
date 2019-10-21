using ECommerce.DataLayer.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Ecommerce.ViewModels
{
    public class RolesModel
    {
        public List<RoleMaster> roles { get; set; }
        public List<UserRole> userRoles { get; set; }
    }


}