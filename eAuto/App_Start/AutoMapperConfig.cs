using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eAuto.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new ObjetosProfile()));
        }
    }

    public class ObjetosProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Models.Marca, DATOS.Marca>();
            Mapper.CreateMap<DATOS.Marca, Models.Marca>();

            Mapper.CreateMap<Models.Pais, DATOS.Pais>();
            Mapper.CreateMap<DATOS.Pais, Models.Pais>();

            Mapper.CreateMap<Models.Modelo, DATOS.Modelo>();
            Mapper.CreateMap<DATOS.Modelo, Models.Modelo>();

            Mapper.CreateMap<Models.Usuario, DATOS.Usuario>();
            Mapper.CreateMap<DATOS.Usuario, Models.Usuario>();

            Mapper.CreateMap<Models.Agencia, DATOS.Agencia>();
            Mapper.CreateMap<DATOS.Agencia, Models.Agencia>();
        }
    }

}