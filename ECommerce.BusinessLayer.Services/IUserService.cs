using Ecommerce.BusinessLayer.Services.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLayer.Services
{
    public interface IUserService
    {
        UserMasterBO UserLogin(string email, string password);
        List<UserMasterBO> GetUser();
    }
}
