using AutoMapper;
using DbManagment.Entities;
using DbManagment.Schema;
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
            CreateMap<User, UserResult>();
        }
    }
}
