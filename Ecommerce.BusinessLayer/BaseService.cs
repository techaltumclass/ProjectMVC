using ECommerce.CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLayer
{

    public abstract class BaseService : MarshalByRefObject
    {
        /// <summary>
        /// Property to get set object mapping instance
        /// </summary>
        [Unity.Dependency]
        public Mapper ObjectMapper
        {
            get;
            set;
        }

        /// <summary>
        /// Struct to get the container instance names for Data/Persistence layer registrations
        /// </summary>
        public struct ContainerDataLayerInstanceNames
        {
            public const string USER_REPOSITORY = "ECommerce_UserDataImpl";

        }

        /// <summary>
        /// Struct to get the container instance names for Business layer registrations
        /// </summary>
        public struct ContainerBusinessLayerInstanceNames
        {
            public const string USER_MANAGER = "ECommerce_UserManager";
        }

    }
}
