﻿using API.Copa.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Copa.Business.Interfaces
{
	public interface ICopaService
	{
		public  Task<Models.CopaModel> RealizarCopa(IEnumerable<Equipe> equipesParticipantes);
	}
}
