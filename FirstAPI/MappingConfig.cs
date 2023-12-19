﻿using AutoMapper;
using FirstAPI.Models;
using FirstAPI.Models.DTO;

namespace FirstAPI
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa,VillaDTO>();
            CreateMap<VillaDTO, Villa>();

            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
        }
    }
}
