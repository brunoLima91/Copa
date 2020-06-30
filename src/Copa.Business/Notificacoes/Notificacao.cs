using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace API.Copa.Business.Notificacoes
{
	public class Notificacao
	{
		public string Mensagem { get; set; }

		public Notificacao(string mensagem)
		{
			Mensagem = mensagem;
		}
	}
}
