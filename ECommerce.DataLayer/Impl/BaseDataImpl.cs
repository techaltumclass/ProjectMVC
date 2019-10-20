using ECommerce.DataLayer.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataLayer.Impl
{
    public abstract class BaseDataImpl
    {
        private ECommerceDataEntities ecommerceDbContext;

        #region Constructors

        /// <summary>
        /// Constructor to intialize database instance for EF
        /// </summary>
        public BaseDataImpl()
        {
            ecommerceDbContext = new ECommerceDataEntities();
        }

        #endregion

        /// <summary>
        /// Property to get db context instance of Entity Framework Database
        /// </summary>
        public ECommerceDataEntities EcommerceDbContext
        {
            get
            {
                return ecommerceDbContext;
            }
        }
    }
}
