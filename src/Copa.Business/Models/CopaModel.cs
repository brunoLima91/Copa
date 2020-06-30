using System;
using System.Collections.Generic;
using System.Text;

namespace API.Copa.Business.Models
{
	public class CopaModel :Entity
	{
		public IList<FaseCopa> Fases { get; set; } = new List<FaseCopa>();
		public Equipe Campeao { get; set; }
		public Equipe ViceCampeao { get; set; }
		public string NomeCampeao { get { return Campeao?.Nome; }}
		public string NomeViceCampeao { get { return ViceCampeao?.Nome; } }
	}
}
