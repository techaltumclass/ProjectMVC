using ECommerce.DataLayer.EDMX;
using ECommerce.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataLayer.Impl
{
    public class UserDataImpl : BaseDataImpl, IUserRepository
    {
        public List<UserMaster> GetUser()
        {
            return EcommerceDbContext.UserMasters.ToList();
        }

        public UserMaster UserLogin(string email, string password)
        {
            return EcommerceDbContext.UserMasters.Where(x => x.cemailaddress == email && x.cpassword == password).FirstOrDefault();
        }
    }
}
