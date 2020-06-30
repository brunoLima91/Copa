using API.Copa.Business.Interfaces;
using API.Copa.Business.Models;
using API.Copa.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Copa.Business.Services
{
	public class JogoService : BaseService, IJogoService
	{
		public JogoService(INotificador notificador): base(notificador)
		{

		}

		public async Task<Jogo> realizarJogo(Equipe Player1, Equipe Player2)
		{
			Jogo lJogo = new Jogo();

			await Task.Run(()  =>
			{
				
				
				if (Player1.Gols == Player2.Gols)
				{
					if (Player1.PosicaoOrigem < Player2.PosicaoOrigem)
					{
						lJogo.Vencedor = Player1;
						lJogo.Perdedor = Player2;
					}
					else
					{
						lJogo.Vencedor = Player1;
						lJogo.Perdedor = Player2;
					}

				}
				else if (Player1.Gols > Player2.Gols)
				{
					lJogo.Vencedor = Player1;
					lJogo.Perdedor = Player2;
				}
				else
				{
					lJogo.Vencedor = Player2;
					lJogo.Perdedor = Player1;
				}

				ExecutarValidacao(new JogoValidation(), lJogo);
					

			});

			return lJogo;
			
		}


	}
}
