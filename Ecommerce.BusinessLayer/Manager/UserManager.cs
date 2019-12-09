using AutoMapper;
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
    public class UserManager : BaseService, IUserService
    {
        [Unity.Dependency(ContainerDataLayerInstanceNames.USER_REPOSITORY)]
        public IUserRepository UserRepository { get; set; }
        private readonly IMapper mapper;

        public UserManager(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public UserMasterBO UserLogin(string email, string password)
        {
            //UserMasterBO user = new UserMasterBO();
            //UserMaster result = UserRepository.UserLogin(email, password);
            //user = Mapper.Map<UserMaster, UserMasterBO> result;
            //ObjectMapper.Map(UserRepository.UserLogin(email, password), user);

            return mapper.Map<UserMasterBO>(UserRepository.UserLogin(email, password));
        }

        public List<UserMasterBO> GetUser()
        {
            return mapper.Map<List<UserMasterBO>>(UserRepository.GetUser());
        }

        public int SubmitUser(UserMasterBO user)
        {
            UserMaster U = mapper.Map<UserMaster>(user);

            return UserRepository.SubmitUser(U);
        }

        public int GetUserRoleID(int userID)
        {
            return UserRepository.GetUserRoleID(userID);
        }
    }
}
