using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Copa.API.ViewModels
{
	public class CopaViewModels
	{
		[Key]
		public Guid Id { get; set; }
		public string NomeCampeao { get; set; }
		public string NomeViceCampeao { get; set; }
		
	}
}
