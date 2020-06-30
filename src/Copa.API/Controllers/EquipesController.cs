using API.Copa.Business.Interfaces;
using Copa.API.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copa.API.Controllers
{
	[Route("api/[controller]")]	
	public class EquipesController : MainController
	{
		public EquipesController(INotificador notificador):base(notificador)
		{

		}

		[HttpGet]
		public async Task<IEnumerable<EquipeViewModel>> ObterEquipes()
		{
			IList<EquipeViewModel> lEquipes = new List<EquipeViewModel>();

			await Task.Run(() =>
			{
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Flamengo 1", Sigla = "FLA1", Gols = 3 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Botafogo 2", Sigla = "BOT2", Gols = 2 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Vasco 3", Sigla = "VAS3", Gols = 5 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Santos 4", Sigla = "SAN4", Gols = 7 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Bahia", Sigla = "BAH", Gols = 9 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Atletico-MG 2", Sigla = "ATM2", Gols = 4 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Cruzeiro 8", Sigla = "CRU8", Gols = 2 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "America-MG", Sigla = "AME", Gols = 1 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Flamengo", Sigla = "FLA", Gols = 3 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Botafogo 23", Sigla = "BOT23", Gols = 2 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Vasco 1", Sigla = "VAS1", Gols = 4 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Flamengo 43", Sigla = "FLA43", Gols = 2 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Bahia 2", Sigla = "BAH2", Gols = 4 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Atletico-MG 5", Sigla = "ATM5", Gols = 4 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "Cruzeiro 1", Sigla = "CRU1", Gols = 2 });
				lEquipes.Add(new EquipeViewModel() { Id = Guid.NewGuid(), Nome = "America-MG 2", Sigla = "AME2", Gols = 1 });
			});
			

			return lEquipes;
		}
	}
}
