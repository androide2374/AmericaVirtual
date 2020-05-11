using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace America_Virtual.Controllers
{
    public class Mapper
    {
        public virtual Entity ModeltoEntity<Model, Entity>(Model source)
        where Entity : class, new()
        {
            return this.Map<Model, Entity>(source);
        }

        public virtual Model EntitytoModel<Entity, Model>(Entity source)
        where Model : class, new()
        {
            return this.Map<Entity, Model>(source);
        }

        /////////(CONFIGURACION DE AUTOMAPPER, NO SE TOCA)///////////////////
        internal virtual T Map<S, T>(S source)
        where T : class, new()
        {
            if (source == null)
                return null;
            if (typeof(T) == typeof(S))
                return source as T;

            T entity = new T();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<S, T>(); });
            config.CreateMapper().Map(source, entity);
            return entity;
        }
    }
    
}