using Ecommerce.BusinessLayer;
using Ecommerce.BusinessLayer.Services;
using Ecommerce.BusinessLayer.Services.BO;
using ECommerce.CommonLayer;
using ECommerce.DataLayer.EDMX;
using ECommerce.DataLayer.Impl;
using ECommerce.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;


namespace Ecommerce.CommonLayer.AOPEngine
{
    public class UnityRegistration
    {
        public static void InitializeAopContainer()
        {
            AopEngine.Initialize();
            InitializeLibrary();
            AopEngine.Container.RegisterType<IMapper, Mapper>(new InjectionMember[] { });
            MapEntities();
        }

        private static void InitializeLibrary()
        {
            InitializeLibraryPersistenceLayer();
            InitializeLibraryBusinessLayer();
        }

        private static void InitializeLibraryPersistenceLayer()
        {
            AopEngine.Container.RegisterType<IUserRepository, UserDataImpl>(GetPersistenceRegisterInstanceName(AspectEnums.PeristenceInstanceNames.UserDataImpl, AspectEnums.ApplicationName.ECommerce));
        }

        private static string GetPersistenceRegisterInstanceName(AspectEnums.PeristenceInstanceNames aspectName, AspectEnums.ApplicationName application)
        {
            return String.Format("{0}_{1}", application.ToString(), aspectName.ToString());
        }

        private static string GetBusinessRegisterInstanceName(AspectEnums.AspectInstanceNames aspectName, AspectEnums.ApplicationName application)
        {
            return String.Format("{0}_{1}", application.ToString(), aspectName.ToString());
        }

        private static void InitializeLibraryBusinessLayer()
        {
            AopEngine.Container.RegisterType<IUserService, UserManager>(GetBusinessRegisterInstanceName(AspectEnums.AspectInstanceNames.UserManager, AspectEnums.ApplicationName.ECommerce));
        }

        private static void MapEntities()
        {
            Mapper mapper = AopEngine.Container.Resolve<Mapper>();
            MapBOEntities(mapper);
        }

        private static void MapBOEntities(Mapper mapper)
        {
            mapper.CreateMap<UserMaster, UserMasterBO>();
            mapper.CreateMap<UserMasterBO, UserMaster>();
        }
    }
}
