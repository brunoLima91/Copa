using API.Copa.Business.Extensions;
using API.Copa.Business.Interfaces;
using API.Copa.Business.Models;
using API.Copa.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Copa.Business.Services
{
	public class FaseFinalService : BaseService, IFaseFinalService
	{
		private readonly IJogoService _jogoService;

		public FaseFinalService(IJogoService jogoService ,INotificador notificador): base(notificador)
		{
			_jogoService = jogoService;
		}
		public async Task RealizarFasesFinais(Models.CopaModel copa, IEnumerable<Equipe> Classificados)
		{
			// realiza semi final 1

			var lFinalista1 = await this.RealizaSemiFinal(new FaseFinal()
			{
				ETipoFase = TipoFase.SemiFinal1,
				Copa = copa,
				NumeroParticipantes = 2,
				Participantes = Classificados
				.Where(x => x.PosicaoOrigem.ToString().In("1", "8", "2", "7"))
				.ToList(),
			});


			if (_notificador.TemNotificacao())
			{
				return;
			}
			// realiza semi final 2
						

			var lFinalista2 = await this.RealizaSemiFinal(new FaseFinal()
			{
				ETipoFase = TipoFase.SemiFinal2,
				Copa = copa,
				NumeroParticipantes = 2,
				Participantes = Classificados
				.Where(x => x.PosicaoOrigem.ToString().In("3", "6", "4", "5"))
				.ToList(),
			});

			if (_notificador.TemNotificacao())
			{
				return;
			}

			// realiza final
			//await RealizarFinal(copa, lFinalista1, lFinalista2);
			await RealizarFinal(new FaseFinal() { 
				ETipoFase = TipoFase.Final,
				Copa = copa,
				NumeroParticipantes = 2,
				Participantes = new List<Equipe>() { lFinalista1, lFinalista2 }
			});
		}

		private async Task ValidarSemiFinal(FaseFinal semiFinal)
		{
			await Task.Run(() => {
				
				if (!ExecutarValidacao(new FaseFinalValidation(), semiFinal))
					return;

				switch (semiFinal.ETipoFase)
				{

					case TipoFase.SemiFinal1:
						if (semiFinal.Participantes.Any(x => x.PosicaoOrigem.ToString().In("3", "6", "4", "5")))
						{
							Notificar("Participante da SemiFInal 1 não é valido, verifique a posição de origem");
						}
						break;
					case TipoFase.SemiFinal2:

						if (semiFinal.Participantes.Any(x => x.PosicaoOrigem.ToString().In("1", "8", "2", "7")))
						{
							Notificar("Participante da SemiFInal 1 não é valido, verifique a posição de origem");
						}
						break;
					default:
						Notificar($"Não é uma Semi Final {semiFinal.ETipoFase}");
						break;
				}
			});
						
		}

		private async Task<Equipe> RealizaSemiFinal(FaseFinal semiFinal)
		{
			await ValidarSemiFinal(semiFinal);
			//retornar vencedor
			var lJogo = await _jogoService.realizarJogo(semiFinal.Participantes.ElementAt(0), semiFinal.Participantes.ElementAt(1));

			if (_notificador.TemNotificacao())
				return null;

			semiFinal.Jogos.Add(lJogo);
			semiFinal.Copa.Fases.Add(semiFinal);
			return lJogo.Vencedor;
		}

		private async Task RealizarFinal(FaseFinal final)
		{
			// validar a entidade nesta fase
			if (!ExecutarValidacao(new FaseFinalValidation(), final))
				return;

			if (final.ETipoFase != TipoFase.Final)
			{
				Notificar("Solicitado realizar final de uma fase que não é final");
				return;
			}


			var lJogo = await _jogoService.realizarJogo(final.Participantes.ElementAt(0), final.Participantes.ElementAt(1));

			if (_notificador.TemNotificacao())
				return;

			final.Copa.Campeao = lJogo.Vencedor;
			final.Copa.ViceCampeao = lJogo.Perdedor;
			final.Copa.Fases.Add(final);
			final.Jogos.Add(lJogo);
			
		}

	}
}
