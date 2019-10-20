using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ECommerce.CommonLayer
{
    public class Mapper : IMapper
    {


        /// <summary>
        /// Method to map object from source into target
        /// </summary>
        /// <typeparam name="T">source generic type</typeparam>
        /// <typeparam name="K">target object generic type</typeparam>
        /// <param name="source">source object</param>
        /// <param name="target">target object</param>
        public void Map<T, K>(T source, K target)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<T, K>(); });
            AutoMapper.IMapper iMapper = config.CreateMapper();
            //var source = new T();
            var destination = iMapper.Map<T, K>(source);
            iMapper.Map(source, target);

        }

        /// <summary>
        /// Method to create register types for auto mapper mapping
        /// </summary>
        /// <typeparam name="T">source generic type</typeparam>
        /// <typeparam name="K">target object generic type</typeparam>
        public MapperConfiguration CreateMap<T, K>()
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<T, K>(); });
            return config;
        }

        /// <summary>
        /// Method to create register types for auto mapper mapping
        /// </summary>
        /// <typeparam name="T">source generic type</typeparam>
        /// <typeparam name="K">target object generic type</typeparam>
        public void CreateMapLeave<T, K>(string sourceProp, string destinationProp)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, K>().ForMember(x => x.GetType().GetProperty(sourceProp), opt => opt.MapFrom(src => src.GetType().GetProperty(destinationProp))); ;
            });
        }

    }
}
