using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace API.Copa.Business.Models.Validations
{
	public class JogoValidation : AbstractValidator<Jogo>
	{
		public JogoValidation()
		{
			RuleFor(x => x.Vencedor)
				.NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

			RuleFor(x => x.Perdedor)
				.NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

			When(j => j.Vencedor != null && j.Perdedor != null, () =>
			{
				RuleFor(j => j.Vencedor.Nome).NotEqual(j => j.Perdedor.Nome)
				.WithMessage("O Vencedor{ComparisonValue} e o Perdedor {PropertyValue} não pode ser a mesma Equipe");
			});
		}
	}
}
