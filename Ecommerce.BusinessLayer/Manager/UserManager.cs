using Ecommerce.BusinessLayer.Services;
using Ecommerce.BusinessLayer.Services.BO;
using ECommerce.DataLayer.EDMX;
using ECommerce.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using static Ecommerce.BusinessLayer.BaseService;

namespace Ecommerce.BusinessLayer
{
    public class UserManager: BaseService, IUserService
    {
        [Unity.Dependency(ContainerDataLayerInstanceNames.USER_REPOSITORY)]
        public IUserRepository UserRepository { get; set; }

        public UserMasterBO UserLogin(string email, string password)
        {
            UserMasterBO user = new UserMasterBO();
            ObjectMapper.Map(UserRepository.UserLogin(email, password), user);
            return user;
        }

        public List<UserMasterBO> GetUser()
        {
            List<UserMasterBO> user = new List<UserMasterBO>();
            ObjectMapper.Map(UserRepository.GetUser(), user);
            return user;

        }
    }
}
