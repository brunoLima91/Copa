using API.Copa.Business.Extensions;
using API.Copa.Business.Interfaces;
using API.Copa.Business.Models;
using AutoMapper;
using Copa.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copa.API.Controllers
{
	[Route("api/[controller]")]
	public class CopaController : MainController
	{
		private readonly ICopaService _copaService;
		private readonly IMapper _mapper;
		public CopaController(ICopaService copaService, IMapper mapper, INotificador notificador) : base(notificador)
		
		{
			_copaService = copaService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<CopaViewModels>> ObterCopaTestes()
		{

			IList<EquipeViewModel> lEquipes = new List<EquipeViewModel>();
			lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Equipe 1", Sigla = "EE", Gols = 3 });
			lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Fogo", Sigla = "EE", Gols = 2 });
			lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Equipe 3", Sigla = "EE", Gols = 5 });
			lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Delta 4", Sigla = "EE", Gols = 7 });
			lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Equipe 5", Sigla = "EE", Gols = 9 });
			lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Sabao 7", Sigla = "EE", Gols = 4 });
			lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Equipe 8", Sigla = "EE", Gols = 2 });
			lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Equipe", Sigla = "EE", Gols = 1 });


			return _mapper.Map<CopaViewModels>( await _copaService.RealizarCopa(_mapper.Map<IEnumerable<Equipe>>(lEquipes)));

			
		}

		[HttpPost]
		public async Task<ActionResult<CopaViewModels>> RealizarCopa(IEnumerable<EquipeViewModel> pEquipes)
		{
			if (pEquipes.Count() != 8)
			{
				NotificarErro("A quantidade de time escolhidos para copa devem ser de 8 ");
				return CustomResponse();
			}

			return _mapper.Map<CopaViewModels>(await _copaService.RealizarCopa(_mapper.Map<IEnumerable<Equipe>>(pEquipes)));
		}
	}
}
