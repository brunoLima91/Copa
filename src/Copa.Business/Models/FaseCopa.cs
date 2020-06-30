using System;
using System.Collections.Generic;
using System.Text;

namespace API.Copa.Business.Models
{
	public abstract class FaseCopa : Entity
	{
		public IList<Equipe> Participantes { get; set; } = new List<Equipe>();
		public int NumeroParticipantes { get; set; }
		public IList<Jogo> Jogos { get; set; } = new List<Jogo>();

		public TipoFase ETipoFase { get; set; }

		public CopaModel Copa { get; set; }


	}
}
