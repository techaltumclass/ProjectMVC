using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.CommonLayer
{
    public interface IMapper
    {
        /// <summary>
        /// Method to Create mapping between two entities/objects
        /// </summary>
        /// <typeparam name="T">Generic type entity to map from</typeparam>
        /// <typeparam name="K">Generic type entity to map</typeparam>
        MapperConfiguration CreateMap<T, K>();

        /// <summary>
        /// Method to map the objects
        /// </summary>
        /// <typeparam name="T">Generic type entity to map from</typeparam>
        /// <typeparam name="K">Generic type entity to map</typeparam>
        /// <param name="source">source object</param>
        /// <param name="target">target object</param>
        void Map<T, K>(T source, K target);
    }
}
