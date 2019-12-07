using AutoMapper;
using Ecommerce.BusinessLayer;
using Ecommerce.BusinessLayer.Services;
using Ecommerce.BusinessLayer.Services.BO;
using ECommerce.BusinessLayer.Services.BO;
using ECommerce.CommonLayer;
using ECommerce.DataLayer.EDMX;
using ECommerce.DataLayer.Impl;
using ECommerce.DataLayer.Repository;
using System;
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
            var config = MapBOEntities();
            AutoMapper.IMapper mapper = config.CreateMapper();
            AopEngine.Container.RegisterInstance(mapper);
        }

        private static MapperConfiguration MapBOEntities()
        {

            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<UserMaster, UserMasterBO>();
                cfg.CreateMap<UserMasterBO, UserMaster>();

                cfg.CreateMap<UserLog, UserLogBO>();
                cfg.CreateMap<UserLogBO, UserLog>();

                cfg.CreateMap<UserRole, UserMasterBO>();
                cfg.CreateMap<UserMasterBO, UserRole>();

                cfg.CreateMap<RoleMaster, UserMasterBO>();
                cfg.CreateMap<UserMasterBO, RoleMaster>();
            });

            return config;
           

        }
    }
}
