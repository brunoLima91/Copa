using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Copa.API.ViewModels
{
	public class EquipeViewModel
	{
		[Key]
		public Guid Id { get; set; }
		[Required(ErrorMessage ="O campo {0} é obrigatório")]
		public string Nome { get; set; }
		[Required(ErrorMessage ="O campo {0} é obrigatório")]
		public string Sigla { get; set; }
		public int Gols { get; set; }
	}
}
