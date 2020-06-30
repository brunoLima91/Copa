namespace API.Copa.Business.Models
{
	public class Jogo : Entity
	{
		public Equipe Vencedor { get; set; }
		public Equipe Perdedor { get; set; }

		
	}
}