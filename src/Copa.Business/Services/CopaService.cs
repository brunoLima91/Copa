using API.Copa.Business.Interfaces;
using API.Copa.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Copa.Business.Services
{
	public class CopaService : BaseService, ICopaService
	{
		private readonly IPrimeiraFaseService _primeiraFaseService;
		private readonly IFaseFinalService _faseFinalService;

		public CopaService(IPrimeiraFaseService primeiraFaseService, IFaseFinalService faseFinalService,
			INotificador notificador): base(notificador)
		{
			_primeiraFaseService = primeiraFaseService;
			_faseFinalService = faseFinalService;
		}

		public async Task<CopaModel> RealizarCopa(IEnumerable<Equipe> equipesParticipantes)
		{
			CopaModel copa = new CopaModel();
			// Realizar Primeira fase
			var lClassificadosFinais = await _primeiraFaseService
				.RetornaClassficadosParaFinais(new PrimeiraFase() { Participantes = equipesParticipantes,
				NumeroParticipantes = 8, Copa = copa });

			if(_notificador.TemNotificacao())
			{
				return null;
			}

			await _faseFinalService.RealizarFasesFinais(copa, lClassificadosFinais);


			return copa;
		}
	}
}
