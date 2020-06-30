using System;
using System.Collections.Generic;
using System.Text;

namespace API.Copa.Business.Models
{
	public class Equipe : Entity
	{
		public string Nome { get; set; }
		public string Sigla { get; set; }
		public int Gols { get; set; }
		public int PosicaoOrigem { get; set; }
	}
}
