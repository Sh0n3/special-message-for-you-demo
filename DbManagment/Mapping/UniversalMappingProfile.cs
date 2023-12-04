using AutoMapper;
using DbManagment.DTOs.Input;
using DbManagment.DTOs.Output;
using DbManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Mapping
{
    public class UniversalMappingProfile : Profile
	{
        public UniversalMappingProfile()
        {
            CreateMap<UserIDTO, User>();
            CreateMap<User, UserODTO>();

            CreateMap<CardIDTO, Card>();
            CreateMap<Card, CardODTO>();
            CreateMap<CardTemplateIDTO, CardTemplate>();
            CreateMap<CardTemplate, CardTemplateODTO>();

            CreateMap<CardImageIDTO, CardImage>();
            CreateMap<CardImage, CardImageODTO>();
        }
    }
}
