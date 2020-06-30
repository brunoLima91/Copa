using API.Copa.Business.Models;
using AutoMapper;
using Copa.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copa.API.Configuration
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<CopaModel, CopaViewModels>().ReverseMap();
			CreateMap<Equipe, EquipeViewModel>().ReverseMap();
		}
	}
}
