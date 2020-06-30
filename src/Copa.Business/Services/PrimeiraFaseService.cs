using API.Copa.Business.Extensions;
using API.Copa.Business.Interfaces;
using API.Copa.Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Copa.Business.Services
{
	public class PrimeiraFaseService : BaseService, IPrimeiraFaseService
	{
		private readonly IJogoService _jogoService;
		public PrimeiraFaseService(IJogoService jogoService ,INotificador notificador):base (notificador)
		{
			_jogoService = jogoService;
		}

		public async Task<IEnumerable<Equipe>> RetornaClassficadosParaFinais(PrimeiraFase primeiraFase)
		{
			// AtualizarPosicaoOrigem
			await this.AtualizarPosicaoOrigem(primeiraFase.Participantes);
			//RealizarJogosPrimeiraFase
			await this.RealizaJogosPrimeraFase(primeiraFase);
			//RetornaClassificados
			primeiraFase.Copa.Fases.Add(primeiraFase);
			return primeiraFase.Jogos.Select(x => x.Vencedor);
		}

		private async Task AtualizarPosicaoOrigem(IEnumerable<Equipe> lParticipantes)
		{
			await Task.Run(() =>
			{
				int posicaoInicial = 1;
				foreach (var lEquipe in lParticipantes.OrderBy(x => x, new OrdenaEquipePorNome()))
				{
					lEquipe.PosicaoOrigem = posicaoInicial;
					posicaoInicial++;
				}
			});
			
		}

		private async Task RealizaJogosPrimeraFase(PrimeiraFase primeiraFase)
		{
			await Task.Run(async () =>
			{

			primeiraFase.Jogos
			.Add(await _jogoService
					.realizarJogo(primeiraFase.Participantes.FirstOrDefault(x => x.PosicaoOrigem == 1)
					, primeiraFase.Participantes.FirstOrDefault(x => x.PosicaoOrigem == 8)));

			primeiraFase.Jogos
				.Add(await _jogoService
						.realizarJogo(primeiraFase.Participantes.FirstOrDefault(x => x.PosicaoOrigem == 2)
						, primeiraFase.Participantes.FirstOrDefault(x => x.PosicaoOrigem == 7)));

			primeiraFase.Jogos
				.Add(await _jogoService
			.realizarJogo(primeiraFase.Participantes.FirstOrDefault(x => x.PosicaoOrigem == 3)
			, primeiraFase.Participantes.FirstOrDefault(x => x.PosicaoOrigem == 6)));

			primeiraFase.Jogos
		.	Add(await _jogoService
			.realizarJogo(primeiraFase.Participantes.FirstOrDefault(x => x.PosicaoOrigem == 4)
			, primeiraFase.Participantes.FirstOrDefault(x => x.PosicaoOrigem == 5)));


			});
		}

	}
}
