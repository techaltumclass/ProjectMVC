﻿using Ecommerce.BusinessLayer.Services;
using ECommerce.CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVC_Ecommerce.Controllers
{
    public class BaseAPIController : ApiController
    {
        private IUserService userBusinessInstance;

        public IUserService UserBusinessInstance
        {
            get
            {
                if (userBusinessInstance == null)
                {
                    userBusinessInstance = AopEngine.Resolve<IUserService>(AspectEnums.AspectInstanceNames.UserManager, AspectEnums.ApplicationName.ECommerce);
                }
                return userBusinessInstance;
            }
        }
    }
}