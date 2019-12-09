using ECommerce.BusinessLayer.Services.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Ecommerce.ViewModels
{
    public class RolesModel
    {
        public List<RoleMasterBO> roles { get; set; }
        public List<UserRoleBO> userRoles { get; set; }
    }


}