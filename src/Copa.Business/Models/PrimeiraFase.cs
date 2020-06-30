using System;
using System.Collections.Generic;
using System.Text;

namespace API.Copa.Business.Models
{
	public class PrimeiraFase : FaseCopa
	{
		public IEnumerable<Equipe> Participantes { get;  set; }


	}
}
