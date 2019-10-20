using ECommerce.DataLayer.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataLayer.Repository
{
    public interface IUserRepository
    {
        UserMaster UserLogin(string email, string password);
        List<UserMaster> GetUser();
    }
}
